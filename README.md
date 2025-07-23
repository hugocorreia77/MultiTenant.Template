# Multi-Tenant User Repository Project

This project implements a multi-tenant user repository system using C# 13.0 and .NET 9. It provides a flexible architecture for managing user data across different tenants, supporting both MongoDB and MySQL as backend databases.

## Features

- **Multi-Tenancy:** Utilizes [Finbuckle.MultiTenant](https://github.com/Finbuckle/Finbuckle.MultiTenant) for tenant context management.
- **Repository Pattern:** Abstracts data access logic for users, supporting multiple database providers.
- **MongoDB & MySQL Support:** Includes implementations for both MongoDB and MySQL repositories.
- **Configurable:** Database connections and settings are managed via configuration files (`appsettings.json`).
- **Extensible:** Easily add new repository providers or extend user models.

## Project Structure

- `Repository.MongoDb.Users.UserRepositoryMongoDb`: MongoDB implementation of the user repository.
- `Repository.MySql.Users.UserRepositoryMySql`: MySQL implementation of the user repository.
- `Repository.Abstractions.Users.IUserRepository`: Interface for user repository operations.
- `Core.Server.Abstractions.Tenant.AppTenantInfo`: Tenant information abstraction.
- `API.WebAPI`: Web API layer exposing endpoints for user operations.
- `Services.Users.UserService`: Service layer for user-related business logic.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- MongoDB or MySQL instance
- Visual Studio 2022

### Configuration

Edit `API/WebAPI/appsettings.json` to configure your database connections:
