# UserManagementAPI

A simple ASP.NET Core 8 Web API demonstrating CRUD user management, server-side validation, EF Core persistence, and custom middleware.

## Features
- GET, POST, PUT and DELETE user endpoints
- DTO validation with DataAnnotations
- EF Core InMemory persistence
- Unique email constraint
- Safe LINQ queries instead of SQL string concatenation
- Request logging middleware
- Swagger/OpenAPI in development
- xUnit validation tests

## Endpoints
- GET `/api/users`
- GET `/api/users/{id}`
- POST `/api/users`
- PUT `/api/users/{id}`
- DELETE `/api/users/{id}`

## Copilot usage
Microsoft Copilot was used during development to generate and enhance CRUD code, suggest validation patterns, identify implementation issues, and improve middleware and test coverage. Generated code was reviewed and tested before inclusion.

## Security and validation
User input is validated through request DTOs and DataAnnotations. Email uniqueness is enforced at the data-model level. EF Core LINQ queries are parameterized by the provider, avoiding SQL string concatenation and reducing SQL injection risk.

## Run
```bash
dotnet restore
dotnet run --project src/UserManagementAPI
```

## Test
```bash
dotnet test
```