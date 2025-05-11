# FitnessTrackerDashboard

**FitnessTrackerDashboard** is an ASP.NET Core Razor Pages web application where users can track their weekly fitness data, including weight and calories. After logging in, users are prompted once per week to submit their fitness entry. The dashboard then displays weekly progress with charts.

---

## Features

- Submit one fitness entry per week (weight and calories)
- Modal appears automatically if no entry is submitted for the current week
- Dashboard with bar and pie charts (Chart.js)
- Session-based login/logout (no ASP.NET Identity)
- Data saved and retrieved from a MySQL database

---

## Getting Started

### Prerequisites

- [.NET SDK 6 or later](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/)
- EF Core CLI tools (`dotnet tool install --global dotnet-ef`)

---

## Setup Instructions

### 1. Create a MySQL Database

Open MySQL and run:

CREATE DATABASE fitness_db;
2. Update the Database Connection
In appsettings.json, update with your actual MySQL credentials:

"ConnectionStrings": {
  "DefaultConnection": "server=localhost;user=root;password=YOUR_PASSWORD;database=fitness_db;"
}

3. Apply Migrations:
Run these commands to create the database tables:
dotnet ef migrations add InitialCreate
dotnet ef database update

Running the App:
Start the application with:
dotnet run
Then open your browser and go to:
📍 http://localhost:5000

Project Structure:
FitnessTrackerDashboard/
├── Models/            # Data models (User, FitnessEntry)
├── Services/          # Service classes for DB operations
├── Pages/             # Razor Pages (Login, Register, Dashboard)
├── appsettings.json   # DB connection and config
└── Program.cs         # Main entry and configuration

How It Works:
After login, if the user hasn't submitted an entry this week, a modal pops up.
The user enters weight and calories and submits the form.
Data is stored in the MySQL DB and shown in the dashboard as bar and pie charts.
One entry is allowed per week.

Notes:
Be sure to change YOUR_PASSWORD in appsettings.json.
If you get an error like Unable to resolve service for type 'FitnessEntryService', make sure the service is registered in Program.cs.
You must be logged in to access the dashboard.

License:
This project is for educational purposes and can be freely used or modified.

Author:
Created by Charbel Nohra
```
