# Pathly – Strategic Productivity Tracker

## About Pathly

Pathly is a strategic productivity tool designed to bridge the gap between high-level ambition and daily execution. I built this because I found that most to-do lists are too cluttered, and most goal-tracking apps are too detached from daily life.

The core philosophy of Pathly is **"Micro-Strategic Planning."** Instead of just listing chores, Pathly encourages users to categorize their efforts into three distinct layers:

* **Goals:** Your north star. These represent the long-term outcomes you are striving for.
* **Roadmaps:** The bridge. These allow you to break down a massive goal into logical phases or milestones.
* **Tasks:** The fuel. These are the daily "micro-actions" that actually move the needle, all linked back to your larger strategy.



Whether you are learning a new language, building a startup, or just trying to organize your personal growth, Pathly provides the structure to ensure that what you do today actually matters for where you want to be tomorrow.

## Features

* **Full CRUD Operations:** Manage Goals, Roadmaps, and Tasks with a seamless interface.
* **Dynamic Dashboard:** Real-time overview of progress and upcoming milestones.
* **Responsive Sidebar Navigation:** A custom-built, collapsible navigation system for a focused workspace.
* **Interactive Roadmap Selection:** View and filter specific paths toward your goals.
* **Robust Validation:** Comprehensive client-side and server-side data integrity.



## Technologies Used

* **Framework:** ASP.NET Core MVC (.NET 8)
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core
* **Frontend:** Bootstrap 5, Custom CSS (Flexbox), JavaScript (ES6)
* **Design Patterns:** MVC, Dependency Injection, SOLID Principles



## Setup and Installation

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or LocalDB
* Visual Studio 2022



### Step-by-Step Instructions

1. Bashgit clone https://github.com/YourUsername/Pathly.git
2. JSON"ConnectionStrings": { "DefaultConnection": "Server=(localdb)\\\\mssqllocaldb;Database=PathlyDb;Trusted\_Connection=True;MultipleActiveResultSets=true"}
3. PowerShellUpdate-Database
4. \*\*Run the Application:\*\*Press F5 or click the "Start" button in Visual Studio. The application will launch at https://localhost:7xxx.



## Architecture \& Best Practices

This project follows **SOLID principles** to ensure maintainability:

* **Single Responsibility:** Controllers handle request routing while business logic and data access are separated.
* **Dependency Injection:** Services and Database Contexts are injected via the standard .NET DI container.
* **Clean UI:** Utilizes Razor Layouts and Partial Views (\_ValidationScriptsPartial, \_Favicons) to minimize code duplication.



## License

This project was developed as part of the SoftUni ASP.NET Core course.

