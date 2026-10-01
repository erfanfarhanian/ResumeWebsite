# Personal Resume & Portfolio Website (v2.0)

[![Framework](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Database](https://img.shields.io/badge/MSSQL-Server-CC292B?style=flat-square&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?style=flat-square)](https://docs.microsoft.com/en-us/ef/core/)
[![Architecture](https://img.shields.io/badge/Architecture-3--Tier%20Layered-blue?style=flat-square)](#)

The complete source code of my personal resume and portfolio website (Version 2.0), built with **ASP.NET Core 8 (.NET 8)**, **Entity Framework Core 8**, and **Microsoft SQL Server**. The solution follows a clean multi-tier layered architecture featuring an interactive public showcase and a comprehensive administrative control panel for real-time portfolio management.

---

## ✨ Key Features

### 👤 Public Showcase
- **Dynamic Resume Presentation:** Career timeline, work experience, academic background, certified licenses, and technical skills loaded dynamically from the database.
- **Project Portfolio Catalog:** Showcase projects categorized with rich details, images, and external links.
- **Blog Section:** Technical articles and insights with category filtering and pagination.
- **Interactive Contact Form:** Secure contact form with client & server-side validation and database logging.
- **Modern & Responsive UI:** Fully responsive layout built with Bootstrap and custom styling, optimized for all screen sizes and mobile devices.

### ⚙️ Admin Control Panel (Dashboard)
- **Role-Based Authentication:** Protected administration area with secure authentication cookies and hashed passwords.
- **Comprehensive CRUD Operations:** Management interfaces for:
  - About Me / Bio / Contact details
  - Experiences & Work History
  - Education & Academic Credentials
  - Skills & Proficiencies
  - Licenses & Certificates
  - Activities & Services
  - Portfolio items & Categories
  - Blog articles & Categories
  - Contact Us messages & inquiries
- **Media & Image Management:** Upload and processing pipeline for portfolio, blog, and avatar media.

---

## 🏗️ Architecture & Project Structure

The solution follows a multi-tier layered architecture (Separation of Concerns):

```
├── Db/                               # Database backup files
│   └── ResumeWebsite_DB              # SQL Server backup file
├── ResumeWebsite/                    # Main Solution directory
│   ├── Resume.Business/              # Business logic, services, helpers & extensions
│   ├── Resume.DAL/                   # Data Access Layer (EF Core, Models, ViewModels, Repositories, Migrations)
│   ├── Resume.Web/                   # Presentation Layer (Controllers, Views, Areas/Admin, ViewComponents)
│   └── ResumeWebsite.sln             # Visual Studio Solution
├── .gitattributes
├── .gitignore
├── LICENSE
└── README.md
```

---

## 🛠️ Tech Stack

- **Backend:** C# 12, ASP.NET Core 8.0 MVC
- **ORM / Data Access:** Entity Framework Core 8.0 (Code-First & Migrations)
- **Database:** Microsoft SQL Server
- **Frontend:** HTML5, CSS3, JavaScript, jQuery, Bootstrap
- **Design Pattern:** Layered Architecture, Repository & Service Pattern
- **Tooling:** Visual Studio 2022 / .NET 8 SDK

---

## 📄 License
This project is open-source and available under the [MIT License](LICENSE).
