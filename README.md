# Personal Resume & Portfolio Website (v2.0)

[![Framework](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Database](https://img.shields.io/badge/MSSQL-Server-CC292B?style=flat-square&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?style=flat-square)](https://docs.microsoft.com/en-us/ef/core/)

The complete source code of my personal resume and portfolio website (Version 2.0), rewritten and upgraded to **ASP.NET Core 8 (.NET 8)** using a clean multi-tier architecture, an interactive public showcase, and an administrative control panel for managing portfolio data.

---

## ✨ Key Features

### 👤 Public Showcase
- **Dynamic Resume Presentation:** Career timeline, work experience, academic background, certified licenses, and technical skills dynamically loaded from the database.
- **Project Portfolio Catalog:** Showcase projects categorized with rich details, images, and external links.
- **Blog Section:** Technical articles and insights with category filtering and pagination.
- **Contact Form & Social Links:** Interactive contact form for visitors with direct database logging, along with dynamic social media channel integrations.
- **Responsive & Modern UI:** Optimized for all screen sizes and mobile devices using Bootstrap and customized styles.

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
- **Image Management:** Secure upload and processing pipeline for portfolio and blog media.

---

## 🏗️ Architecture & Project Structure

The solution follows a multi-tier layered architecture:

```
├── Db/                               # Database backup files
│   └── ResumeWebsite_DB              # SQL Server backup file
├── ResumeWebsite/                    # Main Solution directory
│   ├── Resume.Business/              # Business logic, service implementations, helpers & extensions
│   ├── Resume.DAL/                   # Data Access Layer (EF Core, Models, ViewModels, Repositories, Migrations)
│   ├── Resume.Web/                   # Presentation Layer (Controllers, Views, Areas/Admin, ViewComponents)
│   └── ResumeWebsite.sln             # Visual Studio Solution
├── .gitattributes
├── .gitignore
└── README.md
```

---

## 🛠️ Tech Stack

- **Backend:** C# 12, ASP.NET Core 8.0, Entity Framework Core 8
- **Database:** Microsoft SQL Server
- **Frontend:** HTML5, CSS3, JavaScript, jQuery, Bootstrap
- **Pattern:** Layered Architecture (Repository & Service Pattern)
- **Tooling:** Visual Studio 2022 / .NET 8 SDK

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Microsoft SQL Server](https://www.microsoft.com/sql-server/) (or LocalDB)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) / JetBrains Rider / VS Code

### Database Setup
1. Restore the provided database backup from `Db/ResumeWebsite_DB` in SQL Server Management Studio (SSMS), or apply Entity Framework Core migrations:
   ```bash
   dotnet ef database update --project ResumeWebsite/Resume.DAL --startup-project ResumeWebsite/Resume.Web
   ```
2. Configure your connection string in `ResumeWebsite/Resume.Web/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "ResumeConnectionString": "server = .; Database = ResumeWebsite_DB; Trusted_Connection = true; TrustServerCertificate = true;"
   }
   ```

### Running the Application
```bash
cd ResumeWebsite/Resume.Web
dotnet run
```
Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`.

---

## 📄 License
This project is open-source and available under the [MIT License](LICENSE).
