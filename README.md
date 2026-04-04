![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

# **PATHLY**

> **Bridge the gap between high-level ambition and daily execution with Micro-Strategic Planning.**  
> *Try it out and see for yourself:* [https://pathly.azurewebsites.net](pathly-buaheye9cfh5gkc0.germanywestcentral-01.azurewebsites.net)

![Pathly Logo](Pathly.Web/wwwroot/images/PathlyLogo.png)


## Table of Contents
- [About](#about)
- [User Flow](#user-flow)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup and Installation](#setup-and-installation)
- [Architecture & Best Practices](#architecture--best-practices)
- [Testing & Quality Assurance](#testing--quality-assurance)
- [Future Roadmap](#future-roadmap)
- [Licence](#license)

## **About**

Pathly is a high-performance strategic productivity engine designed to bridge the gap between long-term ambition and daily operational execution. 
By utilizing a **3-Layer Micro-Strategic Planning** framework, Pathly transforms abstract aspirations into actionable, data-driven roadmaps.

The platform is engineered for high-achievers who require a structured environment to manage complex objectives without the overhead of "feature-bloat" 
found in traditional project management suites.

### *The "Problem" vs. The Pathly Solution*

In a world full of distractions, it’s easy to get buried under a pile of small daily chores and lose sight of what you actually want to achieve. 
Most people end up with scattered notes or long to-do lists that don't actually lead anywhere.

Pathly was built to fix this by creating a clear "hierarchy of intent." It replaces messy notebooks and rigid apps with a system where every small task you do today
is directly connected to your "North Star"—your biggest goal.

### *The Core Framework: Micro-Strategic Planning*
 
Pathly organizes productivity into four distinct strategic layers:
 
* **Goals:** Definitive, long-term outcomes that represent your "mountain top." 
 
* **Roadmaps:** Logical deconstruction of goals into manageable phases and milestones.

* **Tasks:** Granular, daily "micro-actions" that drive consistent momentum.

* **Events:** An interactive scheduling layer to manage time-sensitive commitments and deadlines, ensuring your strategy aligns with your actual calendar.
 
Whether you are learning a new language, building a startup, or just trying to organize your personal growth, 
Pathly provides the structure to ensure that what you do today actually matters for where you want to be tomorrow.

## User Flow

### *The Pathly Workflow*

**1. Define the North Star:** Create a **Goal** with a clear deadline, purpose and a description of your ideal outcome.

**2. Build the Strategy:** Generate a **Roadmap** to bridge the gap between where you are now and where you want to be as well as visualize the steps to get there.

**3. Break it Down:** Deconstruct the roadmap into specific **Actions (Milestones)**. This is where you can also upload resources or guides to help you finish the step.

**4. Plan the Time:** Use the **Event Calendar** to mark important deadlines or time-blocks. This helps you see how much time you actually have to work on your goals and
also organize time better.

**5. Execute Daily:** Create specific **Tasks** linked to your milestones. As you complete them on a daily basis, watch your progress bars grow in real-time on the dashboard.

## **Features**

Full CRUD Operations: Manage Goals, Roadmaps, and Tasks with a seamless interface.

Dynamic Dashboard: Real-time overview of progress and a daily reminder of how far you have gone.

![Pathly Logo](Pathly.Web/wwwroot/images/ProgressBars.png)

#### *Visualizing daily execution vs. long-term journey completion.*

\
Responsive Sidebar Navigation: A custom-built, collapsible navigation system for a focused workspace.

Interactive Roadmap Selection: View and filter specific paths toward your goals. After creating one 
you can breake your milestones into daily tasks

Robust Validation: Comprehensive client-side and server-side data integrity.

## **Technologies Used**

### *Backend & Framework:* 

* **[ASP.NET Core 8 (MVC)](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview):** Utilized for high-performance, cross-platform web architecture.

* **[ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity):** For secure, encrypted user authentication and account management.

* **[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/):** Leveraged as a modern ORM for database mapping and migrations.

* **LINQ (Language Integrated Query):** Used for complex data filtering and aggregation for the dashboard.

### *Database:*

* **[Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads):** For relational data storage and integrity.

* **Database Transactions:** Implemented to ensure atomicity during account deletion and multi-step data pruning.

### *Frontend & UI/UX:*

* **[Bootstrap 5](https://getbootstrap.com/docs/5.3/getting-started/introduction/):** For a responsive, mobile-first grid system.

* **Razor Views & Partial Views:** Used for modular, reusable UI components (Modals, Sidebars).

* **[SweetAlert2](https://sweetalert2.github.io/):** For high-end, interactive user confirmation dialogues.

* **[Bootstrap Icons](https://icons.getbootstrap.com/):** For a consistent and intuitive visual language.

* **CSS3 Animations:** Custom `@keyframes` for smooth transitions and the "Pathly" brand feel.

### *JavaScript & Client-Side:*

* **ES6+ JavaScript:** For DOM manipulation and asynchronous form handling.

* **AJAX:** For seamless data loading (Roadmap selection and Task filtering).

* **Client-Side Validation:** [JQuery Validation](https://jqueryvalidation.org/) and Unobtrusive Validation for real-time error handling.

### *Cloud & Storage:*

* **[Azure Blob Storage](https://azure.microsoft.com/en-us/products/storage/blobs/)** - Utilized for scalable, off-server storage of milestone
  resources and user-uploaded documentation.

* **Shared Access Signature(SAS)** - Implemented to provide time-limited, secure, read-only access to private cloud resources, ensuring high data privacy.

* **Browser Local Storage** - Used for persisting client-side UI states, such as sidebar toggle preferences and temporary session data,
  without server overhead.

### *Mapping & Automation:*

* **[AutoMapper](https://automapper.io/)** -  Leveraged for clean Object-to-Object mapping between Domain Entities and ViewModels,
  enforcing a strict separation of concerns and preventing over-posting vulnerabilities.

### *Testing & Quality Assurance:*

* **[NUnit](https://nunit.org/)** -  The primary test runner used for comprehensive Unit and Integration testing across the service layer.

* **[Moq](https://github.com/devlooped/moq)** -  Utilized to isolate business logic by mocking external dependencies such as the Database Context and Azure Storage Clients.

### *Real-Time & Interactive UI:*

* **[SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-10.0)** - Integrated for real-time server-to-client
  notifications (e.g., live progress updates across different dashboard tabs).
  
* **[FullCalendar.js](https://fullcalendar.io/)** - A robust JavaScript library for rendering the interactive event calendar.

* **[SortableJS](https://sortablejs.github.io/Sortable/)** - Used to handle drag-and-drop functionality for the Kanban board

## **Setup and Installation**

### *Prerequisites*

* **Target Framework:** [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

* **IDE:** [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) 

* **Database Engine:** [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads), Developer Edition, or LocalDB.

* **Cloud Storage:** An Azure Storage Account(for Blob storage features during local use)

#### **Optional:**

* **[SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms):** to manage the SQL Server DB

### *Tools:*

* **[Git](https://git-scm.com/):** To clone the repository.

* **EF Core Tools:** (Optional, but recommended) dotnet tool install --global dotnet-ef

* **Modern Browser:** to view the CSS3 animations and flex-layouts correctly.

### *Step-by-Step Instructions*
 
#### **I.Clone the repository**

Open `Git Bash` in the directory you want to download the project and run this command to clone it:

```Bash
 
git clone https://github.com/YourUsername/Pathly.git
 
```

#### **II.Configure User Secrets**
 
Pathly uses **ASP.NET Core User Secrets** to protect sensitive credentials (like Connection Strings and Azure Keys)
Open your terminal in the Pathly.Web project folder and execute the following commands:
##### *1.Initialize Secrets:*

``` Bash
 
dotnet user-secrets init
 
```

##### *2.Initialize Secrets:*

``` Bash
 
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\\mssqllocaldb;Database=PathlyDb;Trusted_Connection=True;MultipleActiveResultSets=true"
 
```

##### *3.Set Azure Storage Credentials:*

``` Bash
 
dotnet user-secrets set "AzureStorage:ConnectionString" "AddYourConnectionString"
dotnet user-secrets set "AzureStorage:ContainerName" "NameOfourStorage"
 
```

*(Do not forget to replace the values with your actual Azure portal credentials)*

#### **III.Initialize the Database**

Apply the Entity Framework migrations to create your local schema and seed initial data:

* **Via Package Manager Console (Visual Studio):**

```PowerShell
 Update-Database
```

**Note!**: Make sure that the **Default Project** is set to `Pathly.Web` 

* **Via .NET CLI:**

```Bash
 dotnet ef database update
```

#### **4.Run the Application:**
Press `F5` or click the `"Start"` button in Visual Studio. The application will launch at:

```PlainText
https://localhost:7xxx.
```

**Note!**: If it does not start check if the **startup project** is set to `Pathly.Web` and that next to the start/play button says `https`.  
To configure the startup project: `Right Click on the solution > Configure Startup Project > Check Single Startup Project` and then select Pathly.Web from the dropdown menu.

## **Architecture & Best Practices**
The project follows a **Logically Decoupled 3-Layer Architecture**. It utilizes the **Service-Repository Pattern** to separate concerns 
between the UI (Presentation), Business Logic (Services), and Data Persistence (EF Core).

### *Key Design Decisions*

* **Azure Blob Storage vs. Local Storage for Resources:** Opted for Cloud storage to ensure the application is scalable and stateless. This decouples user assets from the web server, improving performance and security.

* **AutoMapper Integration:** Used to enforce a strict boundary between Domain Entities and ViewModels. This prevents "Overposting" attacks and ensures that the internal database schema is never exposed directly to the client.

* **Service-Repository Pattern:** Business logic is abstracted into dedicated Services (e.g., `RoadmapService`, `BlobService`), keeping controllers "thin" and focused solely on request routing.

### *Data Integrity & Validation*

### *Database Schema & Data Integrity*

Pathly implements a multi-layered validation strategy to ensure data remains consistent and secure:

* **Server-Side:** Robust **Data Annotations** (`[Required]`, `[MaxLength]`,`[MinLength]`) coupled with custom logic in the service layer.

* **Client-Side:** Real-time feedback via **jQuery Unobtrusive Validation** for a seamless user experience.

* **Security Validations:** Implementation of **Anti-Forgery Tokens (CSRF protection)** and strict filename sanitization for all Azure Blob uploads.

![Pathly Logo](Pathly.Web/wwwroot/images/EntityRealationship.png)

* **Multi-Tenant Isolation:** The schema is strictly anchored to `AspNetUsers`, ensuring that every Goal, Roadmap, and Task is isolated per user.

* **Relational Hierarchy:** Implements a structured One-to-Many flow (`User → Goals → Roadmaps → Actions → Tasks`) with a Many-to-Many relationship for `Task Tags`.

* **Referential Integrity & Cascading:** Custom recursive logic handles complex deletions across linked entities,
  ensuring the database remains free of orphaned records.

### *Automated Data Seeding*

#### To ensure a smooth functional experience for new developers and examiners:

* **System Seeders:**: Implemented within `OnModelCreating`, the system automatically populates the database with initial
  `Tags`,`Tasks`,`Goals`,`Users`, etc. and system-level configurations.

### *Software Principles:*

* *Open/Closed:* The architecture allows for adding new goal types or roadmap structures without modifying existing core logic.
* **Dependency Injection (DI):** Utilizes the built-in .NET IoC container to manage the lifecycle of the `ApplicationDbContext` and other services.
* **Dual-Layer Validation:**
  * **Server-Side:** Robust Data Annotations and custom logic ensure data integrity.
  * **Client-Side:** jQuery Unobtrusive Validation provides an immediate, premium user experience. 
* **DRY (Don't Repeat Yourself):** Leverages **Partial Views** and **View Components** to modularize the UI, significantly reducing maintenance overhead.
* **Asynchronous I/O:** All database and storage operations (Azure Blobs) are implemented with `async/await`.

## **Testing & Quality Assurance**

The reliability of Pathly's core logic is backed by a comprehensive tests, ensuring that strategic calculations and data flows remain accurate.

* **High-Confidence Coverage:** Maintained **85%+ Unit Test coverage** across the entire service layer using **NUnit**.

* **Mocking Strategy:** Utilized **Moq** to isolate business logic, allowing for tests that verify behavior without requiring a live database or Azure connection.

* **Edge-Case Focus:** Testing goes beyond "happy path" scenarios. The suite includes:
  
  * **Resource Handling:** Verifying system behavior when file uploads are interrupted or missing.
 
  * **Empty State Management:** Ensuring roadmaps behave correctly even when milestones or actions are not yet defined.
 
  * **Progress Logic:** Validating that progress bar percentages are mathematically accurate across different goal types.

## **Future Improvements**

### *Future Roadmap*

#### Pathly is continuously evolving. Planned features for upcoming releases include:

* **Social Accountability:** The ability to share goals and key milestones with a community of users for mutual encouragement and public "Path" tracking.

* **AI-Assisted Deconstruction:** Integration with LLMs to suggest logical milestones and roadmap structures based on the user's high-level goal.

* **Data Analytics Suite:** Advanced insights into productivity trends, helping users identify which "Paths" are thriving and where focus is lagging over time.

## **License**

Distributed under the **MIT License**. See the `LICENSE` file in the root directory for more information.
