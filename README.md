# Welcome to the Corona Management System for Health Funds!

## System Description

The Corona Management System for Health Funds was developed to streamline the management of COVID-19 related information among members of health funds. This system provides comprehensive features for tracking vaccination records, managing member data, and monitoring pandemic-related data.

## Table of Contents
- [System Features](#system-features)
- [System Architecture](#system-architecture)
- [Data Protection](#data-protection)
- [Requirements](#requirements)
- [Installation Instructions](#installation-instructions)
- [Screenshots](#screenshots)
- [Contact Us](#contact-us)

## System Features

- **Advanced Database:** Stores personal records of health fund members, including personal details and COVID-19 related data.
- **Member Management:** Ability to add, edit, and delete existing members of the health fund.
- **Vaccination Tracking:** Documentation and management of COVID-19 vaccination processes for each member.
- **Pandemic Data Management:** Recording and managing data on positive cases, recoveries, and relevant event dates.

## System Architecture

The application follows a client-server architecture, with a client-side application interacting with server-side APIs, which in turn interacts with a database to store and retrieve information. Here's how the various components of the system interact:

### Client-Side Application:

- Developed in HTML, CSS, and JavaScript, the client-side application is responsible for presenting the user interface (UI) to the end-users.
- It communicates with the server-side APIs, to perform CRUD (Create, Read, Update, Delete) operations and retrieve data via HTTP requests (GET, POST, PUT, DELETE) over the network.

### Server-Side APIs:

- The server-side APIs, developed in .NET using Entity Framework, act as an intermediary between the client-side application and the SQL Server database.
- They handle incoming HTTP requests from the client-side application and execute corresponding logic.
- Server-side APIs interact with the SQL Server database to perform database operations such as inserting, querying, updating, and deleting data.

### Database:

- The database stores the application's data in a structured format.
- It consists of tables to organize data.
- Entity Framework is used for communication between the server-side APIs and the SQL Server database.

### Schematic View of Information in the Database:

-  User Table: Stores information about registered users and information related to their COVID-19 details.
- Vaccinations Table: Stores information about different types of vaccinations available.
- User Vaccinations Table: Represents the association between users and their vaccinations.

Access to vaccine list information (addition, deletion, etc.) is done through the Swagger user interface.

### Illustrative illustrations:

<img src="https://github.com/noa1020/Hadasim_Home-exercises/assets/146897162/923dc814-0a23-47e6-8999-dfbe6b449709" alt="Architectural specification" width="450" style="border:1px solid black">

<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/93c921e4-2e64-4ddb-8c55-a7a66424ad2b" alt="database" width="600" style="border:1px solid black">

## Data Protection

The system uses a SQL Server database to store data, ensuring data integrity and preventing foot faults.

## Requirements

- .NET Framework 4.7.2 or higher
- SQL Server
- Web browser with support for HTML5 and CSS3

## Installation Instructions

1. Download the code files from GitHub.
2. Install the required development environment.
3. Start the server and the database.
4. Launch the client on a web browser.
5. Conect Swgger to add vaccinations.


## Screenshots

### Homepage:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/d7ace8c0-9828-4363-b9f9-ea4d2aa284b7" alt="Homepage" width="600" style="border:1px solid black">

### Statistics on Covid19:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/59103e20-e303-490a-b217-c9a48f660beb" alt="Statistics on Covid19" width="600" style="border:1px solid black">

### Adding New Member:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/c9918061-a23b-4490-9c08-fcccfe2008b5" alt="Adding New Member 1" width="300" style="border:1px solid black">
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/c2b7613b-0bcb-430c-a91f-275011e298da" alt="Adding New Member 2" width="300" style="border:1px solid black">
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/b502b154-2d4b-4fb4-a087-5850f19df218" alt="Adding New Member 3" width="300" style="border:1px solid black">

### Basic Member Information:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/914b8924-730a-4f00-ac7e-6752250882d3" alt="Basic Member Information" width="600" style="border:1px solid black">

### Edit Member Details:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/1f419929-a014-495b-9091-1fed2e2dedd3" alt="Edit Member Details" width="600" style="border:1px solid black">

### Member Covid19 Details:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/dbb27ad9-7dc6-4519-9e52-1ab9291995f0" alt="Member Covid19 Details" width="600" style="border:1px solid black">

### Editing a Particular Vaccine:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/fcfc0f1f-51b8-4f96-ab3b-68c408cac824" alt="Editing a Particular Vaccine" width="600" style="border:1px solid black">

### Edit/Add a Sick or Recovery Day:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/e5a4c922-e332-4316-8474-98f536263147" alt="Edit/Add a Sick or Recovery Day" width="600" style="border:1px solid black">

### Add Vaccination:
<img src="https://github.com/noa1020/Corona_management-system/assets/146897162/6b745e71-5c84-4a4e-824c-29d5455c9ecc" alt="Add Vaccination" width="400" style="border:1px solid black">

## Contact Us

For any questions or further assistance, please contact us via email: Noa0533181648@gmail.com or through our social media profiles.
