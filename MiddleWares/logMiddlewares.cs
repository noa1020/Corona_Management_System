using System.Diagnostics;

namespace CoronaManagementSystem.Middlewares;

public class MyLogMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger logger;


    public MyLogMiddleware(RequestDelegate next, ILogger<MyLogMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    private readonly object fileWriteLock = new object();

    public async Task Invoke(HttpContext c)
    {
        var sw = new Stopwatch();
        sw.Start();
        await next.Invoke(c);

        string logMessage = $" date: {DateTime.Now.ToShortDateString()}, beginning time: {DateTime.Now.TimeOfDay}, controller name: {c.Request.Path}, action: {c.Request.Method},"
             + $" user name: {c.User?.FindFirst("userId")?.Value ?? "unconnected"},"
              + $" duration: {sw.ElapsedMilliseconds}ms.";

        lock (fileWriteLock)
        {
            WriteToFile(logMessage);
        }
    }
    private void WriteToFile(string logMessage)
    {
        using (StreamWriter writer = new StreamWriter("log.txt", true))
        {
            writer.WriteLine(logMessage);
        }
    }
}

public static partial class MiddlewareExtensions
{
    public static IApplicationBuilder UseMyLogMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyLogMiddleware>();
    }
}