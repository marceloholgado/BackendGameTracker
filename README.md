
### Domain
- Pure business rules
- Entities and Value Objects
- No dependencies on external frameworks

### Application
- Use Cases (application services)
- DTOs
- Interfaces and contracts
- Coordinates domain logic

### Infrastructure
- Technical implementations
- Repository implementations
- Entity Framework Core
- Data persistence

### API
- Controllers
- HTTP input/output
- Acts as a thin layer that delegates work to the Application layer

---

## 🧪 Testing

Each layer has its own test project:

- Domain.Tests → business rules and invariants
- Application.Tests → use cases and workflows
- Infrastructure.Tests → persistence and integration behavior

The tests focus on:
- Domain integrity
- Business rule validation
- Correct use case execution

---

## 🚀 Technologies Used

- .NET
- ASP.NET Core
- Entity Framework Core
- xUnit / NUnit (testing)
- REST API

---

## 📌 Notes

- This project is a work in progress
- Architectural decisions may evolve as new concepts are explored
- The main priority is **learning, clarity, and separation of concerns**

---

## 👨‍💻 Author

Project created for studying and experimenting with **Domain-Driven Design (DDD)**.
