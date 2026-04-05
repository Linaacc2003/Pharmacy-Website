# Pharmacy Management System 🏥💊

Modern, efficient, and robust web application for managing day-to-day pharmacy operations, built with **ASP.NET Core MVC**. 

## ✨ Features
- **Secure Access:** Animated, modern login portal as the default landing page. Pre-configured admin accounts.
- **Supplier Management:** Full CRUD (Create, Read, Update, Delete) capability to track suppliers, contact information, and medication inventory.
- **Prescription Tracking:** Efficiently manage and verify patient prescriptions.
- **Role-Based Entities:** Includes modules for Patients, Pharmacists, Suppliers, and Prescriptions.
- **Modern UI:** Designed with an elegant "Emerald Green" aesthetic, sleek floating cards, and smooth CSS integrations for a premium user experience.

## 🛠️ Tech Stack
- **Framework:** ASP.NET Core 8 MVC
- **Language:** C#
- **Frontend:** HTML5, CSS3 (Custom animations), Bootstrap, Razor Pages (`.cshtml`)
- **Database Access:** Entity Framework Core (EF Core) & ADO.NET mix

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or higher.
- SQL Server (or LocalDB).
- Visual Studio 2022 or VS Code.

### Installation & Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Linaacc2003/Pharmacy-Website.git
   cd Pharmacy-Website/myprojectpharmacy
   ```

2. **Database Setup:**
   The connection string is configured in `appsettings.json`. By default, it uses a local SQL Server. If needed, apply Entity Framework migrations to structure your database:
   ```bash
   dotnet ef database update
   ```

3. **Run the Application:**
   ```bash
   dotnet run
   ```
   *The application will automatically direct you to the animated `/Account/Login` portal.*

### 🔑 Default Credentials
If running out of the box, an initial admin user is seeded into the database:
- **Username:** `lina`
- **Password:** `0000`

---
*Maintained by Linaacc2003.*
