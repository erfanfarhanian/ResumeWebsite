# وب‌سایت رزومه و پورتفولیو شخصی (نسخه ۲.۰)

[![Framework](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Database](https://img.shields.io/badge/MSSQL-Server-CC292B?style=flat-square&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?style=flat-square)](https://docs.microsoft.com/en-us/ef/core/)
[![Architecture](https://img.shields.io/badge/Architecture-3--Tier%20Layered-blue?style=flat-square)](#)

این مخزن شامل سورس‌کد کامل وب‌سایت رزومه و نمونه‌کارهای شخصی من (نسخه ۲.۰) است که با استفاده از **ASP.NET Core 8 (.NET 8)**، تکنولوژی **Entity Framework Core 8** و دیتابیس **Microsoft SQL Server** پیاده‌سازی شده است. معماری پروژه به‌صورت چندلایه‌ای و تمیز طراحی شده و دارای بخش عمومی نمایش رزومه و پنل مدیریت جامع جهت مدیریت آنلاین محتوا است.

---

## ✨ امکانات و قابلیت‌های کلیدی

### 👤 بخش عمومی (کاربران و بازدیدکنندگان)
- **نمایش داینامیک رزومه:** بارگذاری سوابق شغلی، مدارک و مقاطع تحصیلی، مهارت‌های تخصصی، مجوزها و دوره‌ها به‌صورت پویا از دیتابیس.
- **کاتالوگ نمونه‌کارها (Portfolio):** معرفی پروژه‌ها به همراه دسته‌بندی موضوعی، تصاویر و جزییات فنی.
- **بخش وبلاگ:** مقالات و مطالب آموزشی با قابلیت دسته‌بندی و صفحه‌بندی (Pagination).
- **فرم ارتباط با من:** فرم ارسال پیام با اعتبارسنجی سمت کلاینت و سرور و ذخیره‌سازی در دیتابیس.
- **طراحی مدرن و کاملاً واکنش‌گرا (Responsive):** بهینه‌سازی شده برای انواع نمایشگرها و دستگاه‌های موبایل با Bootstrap و استایل‌های سفارشی.

### ⚙️ پنل مدیریت (Admin Dashboard)
- **احراز هویت و امنیت:** ورود مدیر با نشست‌های امن و رمزگذاری کلمات عبور.
- **مدیریت کامل اطلاعات (CRUD):**
  - درباره من (بیوگرافی، مشخصات و راه‌های ارتباطی)
  - سوابق شغلی و تجربیات کاری
  - سوابق تحصیلی
  - مهارت‌های فنی و فردی
  - مدارک و گواهینامه‌ها
  - فعالیت‌ها و خدمات
  - پروژه‌های نمونه‌کار و دسته‌بندی‌ها
  - مقالات وبلاگ و دسته‌بندی‌ها
  - صندوق پیام‌های دریافتی از کاربران
- **مدیریت فایل‌ها و تصاویر:** آپلود و مدیریت تصاویر پروژه‌ها، مقالات و آواتار.

---

## 🏗️ معماری و ساختار پروژه

پروژه با ساختار لایه‌ای و ماژولار (Separation of Concerns) توسعه داده شده است:

```
├── Db/                               # بک‌آپ دیتابیس SQL Server
│   └── ResumeWebsite_DB              # فایل بک‌آپ دیتابیس پروژه
├── ResumeWebsite/                    # پوشه اصلی راه‌حل (Solution)
│   ├── Resume.Business/              # لایه منطق کسب‌وکار، سرویس‌ها، توابع کمکی و Extensionها
│   ├── Resume.DAL/                   # لایه داده (EF Core، مدل‌ها، ویومدل‌ها، ریپازیتوری‌ها و مایگریشن‌ها)
│   ├── Resume.Web/                   # لایه ارائه‌ی وب (کنترلرها، ویوها، بخش مدیریت Areas/Admin و کامپوننت‌ها)
│   └── ResumeWebsite.sln             # فایل راه‌حل ویژوال استودیو
├── .gitattributes
├── .gitignore
├── LICENSE
└── README.md
```

---

## 🛠️ تکنولوژی‌ها و ابزارهای مورد استفاده

- **Backend:** C# 12, ASP.NET Core 8.0 MVC
- **ORM / Data Access:** Entity Framework Core 8.0 (Code-First & Migrations)
- **Database:** Microsoft SQL Server
- **Frontend:** HTML5, CSS3, JavaScript, jQuery, Bootstrap
- **Design Pattern:** Layered Architecture, Repository & Service Pattern
- **Tooling:** Visual Studio 2022 / .NET 8 SDK

---

## 📄 لایسنس
این پروژه تحت لایسنس [MIT](LICENSE) منتشر شده است.
