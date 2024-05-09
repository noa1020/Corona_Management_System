// Fetches not vaccinated members count from the server
async function GetNotVaccinated() {
    const response = await fetch('/NotVaccinatedCount', {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    });
    if (!response.ok) {
        const errorMessage = await response.text();
        const errorMessageFirstLine = errorMessage.split(' at ')[0];
        throw new Error(errorMessageFirstLine);
    }
    const data = await response.json();
    return data;
}

//Displaying the amount of unvaccinated members
async function DisplayNotVaccinatedCount() {
    try {
        const unvaccinatedCountDisplay = document.getElementById("unvaccinatedCountDisplay");
        const notVaccinatedCount = await GetNotVaccinated();
        unvaccinatedCountDisplay.innerHTML = "There are " + notVaccinatedCount + " unvaccinated HMO members";
    } catch (error) {
        console.error('Error getting members.', error);
    }
}

//Fetches all the dates someone was sick
async function GetDatesOfIllness() {
    const response = await fetch('/DatesOfIllness', {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    });
    if (!response.ok) {
        const errorMessage = await response.text();
        const errorMessageFirstLine = errorMessage.split(' at ')[0];
        throw new Error(errorMessageFirstLine);
    }
    const data = await response.json();
    return data;
}

//Processing the information and presenting it in a graph
async function DisplayGraph() {
    const datesOfIllness = await GetDatesOfIllness();

    const dates = [];
    const counts = [];

    datesOfIllness.forEach(date => {
        const dateString = new Date(date).toISOString().split('T')[0];
        const index = dates.indexOf(dateString);
        if (index !== -1) {
            counts[index]++;
        } else {
            dates.push(dateString);
            counts.push(1);
        }
    });
    dates.sort();
    const ctx = document.getElementById('myChart').getContext('2d');
    window.myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: dates,
            datasets: [{
                label: 'Number of patients per day',
                data: counts,
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgba(255, 99, 132, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

// Initial call to fetch items
(async () => {
    try {
        vaccinationsArr = await GetVaccination();
        await GetMembers();
        await DisplayNotVaccinatedCount();
    } catch (error) {
        alert(error.message);
    }
})();
DisplayGraph();
