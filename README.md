# 🎾 PadelStore – ASP.NET Core MVC Web Application

## 📌 Project Overview

PadelStore is a full-featured web application for browsing, purchasing, and managing padel equipment.  
The system supports both regular users and administrators, providing a complete e-commerce experience.

The project is built using **ASP.NET Core MVC**, following best practices for software architecture, security, and maintainability.

---

## 🚀 Features

### 👤 User Features
- Register and Login (ASP.NET Identity)
- Browse products with pagination
- Search and filter products (by category and brand)
- View product details
- Add products to cart
- Manage cart (increase/decrease quantity)
- Place orders
- View personal orders
- Leave product reviews

---

### 👑 Admin Features
- Admin panel (separate Area)
- Create, edit, delete products
- Manage categories and brands
- View and process orders
- Manage users
  - Assign roles 
  - Remove roles
  - Delete users
- Manage reviews

---

## 🧱 Architecture

The application follows a **layered architecture**:


PadelStore

- ** Data (Entities, DbContext, Configurations, Seeding)
- ** Services (Interfaces and services)
- ** Web (Controllers, Views,ViewModels, Areas, Infrastructure)
- ** UnitTests

## ⚙️ Installation & Setup

### 1️⃣ Clone the repository
```
git clone https://github.com/your-username/PadelStore.git
```
### 2️⃣ Configure database connection
In appsettings.json, update the connection string:

```
"DefaultConnection": "Server=localhost\\MSSQLSERVER01;Database=PadelStore;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False;"
```
Change only the server name to match your local SQL Server instance, for example:

```
localhost\SQLEXPRESS

DESKTOP-12345\SQLEXPRESS

localhost
```

### 3️⃣ Apply migrations
```
Update-Database
```
### 4️⃣ Run the application
Start the project from Visual Studio or Rider.


### 🔹 Principles Used
- Separation of Concerns
- Dependency Injection
- Loose Coupling & High Cohesion
- SOLID principles

---

## 🗄️ Database

- Microsoft SQL Server
- Entity Framework Core

### 📊 Main Entities
- Product
- Category
- Brand
- CartItem
- Order
- OrderItem
- Review
- ApplicationUser (extended Identity)

---

## 🌱 Data Seeding

The database is seeded with:
- 4 Categories
- 4 Brands
- 13 Products
- Admin user and roles

Seeding is implemented using **Entity Configuration classes**.

---

## 🔐 Security

The application includes protection against common vulnerabilities:

- ✔ Authentication & Authorization (ASP.NET Identity)
- ✔ Role-based access (Admin/User)
- ✔ CSRF protection (AntiForgeryToken)
- ✔ XSS protection (Razor encoding)
- ✔ Parameter validation
- ✔ Soft delete (prevents data loss)

---

## ⚙️ Technologies Used

- ASP.NET Core MVC (.NET 6+)
- Entity Framework Core
- Microsoft SQL Server
- ASP.NET Identity
- Bootstrap (responsive UI)
- Razor Views

---

## 📄 Error Handling

Custom error pages:
- 404 Not Found
- 500 Internal Server Error

Global exception handling is implemented using middleware.

---

## 🔍 Additional Features

- Pagination
- Search functionality
- Filtering
- Responsive design
- Role-based UI rendering

---

## 🧪 Unit Testing

Unit tests are implemented for:
- Service layer (business logic)
- Key operations such as create, delete, filtering

---

## 👤 Default Admin


Email: admin@admin.bg

Password: 123456


---


## 🎯 Project Purpose

This project demonstrates:
- Advanced ASP.NET Core development skills
- Clean architecture and maintainable code
- Secure web application practices
- Real-world e-commerce functionality

---

## 📌 Author

- Iliyan Sidzhimkov
- SoftUni ASP.Net Advanced Final Project
