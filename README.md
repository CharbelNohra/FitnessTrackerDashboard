# 🏋️‍♂️ FitnessTrackerDashboard

**FitnessTrackerDashboard** is an ASP.NET Core Razor Pages web application that allows users to track their weekly fitness data, including weight and calorie intake. Users are prompted once per week to submit their fitness entry, and the dashboard visually displays progress using charts.

---

## 🚀 Features

- ➕ Submit one fitness entry per week (weight and calories)
- 🔔 Automatic modal prompt if no entry has been submitted for the current week
- 📊 Interactive bar and pie charts (powered by Chart.js)
- 🔐 Session-based authentication (no ASP.NET Identity)
- 💾 Data persistence using MySQL and Entity Framework Core

---

## 📦 Getting Started

### ✅ Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/)
- EF Core CLI tools:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

## ⚙️ Setup Instructions

### 1. Create the MySQL Database

Open MySQL and run the following:

```sql
CREATE DATABASE fitness_db;
```

### 2. Configure the Connection String

In `appsettings.json`, update your MySQL credentials:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;user=root;password=YOUR_PASSWORD;database=fitness_db;"
}
```

### 3. Apply Migrations

Run the following commands to set up your database schema:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## ▶️ Running the App

Start the development server with:

```bash
dotnet run
```

Then visit the application in your browser at:

[http://localhost:5000](http://localhost:5000)

---

## 📁 Project Structure

```
FitnessTrackerDashboard/
├── Models/            # Data models (User, FitnessEntry)
├── Services/          # Business logic and DB services
├── Pages/             # Razor Pages (Login, Register, Dashboard)
├── appsettings.json   # Configuration and connection strings
└── Program.cs         # App startup and service configuration
```

---

## 🔍 How It Works

1. Users log in using their credentials.
2. If they haven’t submitted data for the current week, a modal automatically prompts them to do so.
3. After submission, entries are stored in the MySQL database.
4. The dashboard displays fitness trends through bar and pie charts.
5. Only one entry is allowed per user per week.

---

## ⚠️ Notes

- Replace `YOUR_PASSWORD` in `appsettings.json` with your actual MySQL password.
- If you encounter an error like:

  ```
  Unable to resolve service for type 'FitnessEntryService'
  ```

  Ensure the service is properly registered in `Program.cs`.
- The dashboard is only accessible after logging in.

---

## 📄 License

This project is intended for educational purposes and can be freely used or modified.

---

## 👨‍💻 Author

**Charbel Nohra**
