# 📝 TaskManagement

A clean, modular, and testable Task Management REST API built with **ASP.NET Core**, **Entity Framework Core**, and **Clean Architecture principles**.

---

## 📦 Project Structure

This project follows **Clean Architecture**, separating concerns across multiple layers:

TaskManagement.sln
│
├── TaskManagement.Domain # Core entities and repository interfaces
├── TaskManagement.Application # Business logic and use case services
├── TaskManagement.Infrastructure # EF Core DbContext and repository implementations
├── TaskManagement.Api # ASP.NET Core Web API
└── TaskManagement.Tests # xUnit test project with Moq

---

## ⚙️ Technologies Used

- ✅ .NET 9.0 (with GitHub Actions support)
- ✅ ASP.NET Core Web API
- ✅ Entity Framework Core (Code First + Migrations)
- ✅ xUnit + Moq for unit testing
- ✅ Swagger for API documentation
- ✅ GitHub Actions (CI/CD for running tests on push/PR)

---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- SQL Server (LocalDB or Express)
- Git

### 🛠 Setup Instructions

1. Clone the repo:

git clone https://github.com/YOUR_USERNAME/TaskManagement.git
cd TaskManagement

2. Apply migrations and create the database:

dotnet ef database update --project TaskManagement.Infrastructure --startup-project TaskManagement.Api

3. Run the API:

dotnet run --project TaskManagement.Api

4. Visit Swagger:

https://localhost:7037/swagger

✅ Features

- Create, Read, Update, Delete tasks

- Clean layered architecture

- Global error handling

- EF Core migrations and SQL Server integration

- Unit tests with xUnit and mocking with Moq

- GitHub Actions for CI

🧪 Running Tests

dotnet test

📸 Swagger UI
Visit /swagger for live documentation and testing.

📂 Example Task JSON

{
  "title": "Build README",
  "description": "Write a detailed project overview",
  "dueDate": "2025-07-10T12:00:00Z"
}

📃 License
MIT License - free to use, modify, or contribute!

🙌 Contributing
Pull requests are welcome! Feel free to open issues or suggest improvements.

Built with ❤️ by Eric
