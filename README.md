# Multi-Tenant Polimorphic Template

This project is a multi-tenant polimorphic template for .NET web api project using C# 13.0 and .NET 9. It provides a flexible architecture for managing data across different tenants, supporting, at the moment, MongoDB and MySQL as backend databases. But you can easily set up your own!

**Polimorphic?**
Just a fancy word, meaning that you can set and update at any moment the repository that any your tenant wants to use.
All you need is to have a repository implementation for a specifiic database technology, and a repository configuration object matching what you control plane configures (Connection string, database name, ...).

It uses the vertical slices architecture:
- API / Use cases
- Services
- Repositories

## Wich Multi-tenant arquitecture does it supports?
This template can use any of common tenancy models:
Please, check [Microsoft Tenancy Models](https://learn.microsoft.com/en-us/azure/architecture/guide/multitenant/considerations/tenancy-models)

## Wich Multi-tenant strategy does it supports?
Easy answer: All! :D 
For demonstration purpose, it uses [Host Strategy](https://www.finbuckle.com/MultiTenant/Docs/v9.2.2/Strategies), but you can easily change for your use case. Check [Finbuckle multiTenant strategies](https://www.finbuckle.com/MultiTenant/Docs/v9.2.2/Strategies).


## Features

- **Multi-Tenancy:** Utilizes [Finbuckle.MultiTenant](https://github.com/Finbuckle/Finbuckle.MultiTenant) for tenant context management.
- **Repository Pattern:** Abstracts data access logic for users, supporting multiple database providers.
- **MongoDB & MySQL Support:** Includes implementations for both MongoDB and MySQL repositories.
- **Configurable:** Database connections and settings are managed via a control plane repository in memory simulator.
- **Extensible:** Easily add new repository providers and data stores

## Project Structure

- `API.WebAPI`: Web API layer exposing endpoints for user operations.
- `Core.Server.Abstractions`: Shared core objects for multi-tenancy and repository configuration
- `Services.Abstractions`: DTOs and Services contracts 
- `Services.Users`: Users Services implementations to manage users 
- `Repository.Abstractions`: Configurations, database models and contracts.
- `Repository.MongoDb`: MongoDB implementation of the repository.
- `Repository.MySql`: MySQL implementation of the repository.
- `Repository.TenantControlPlane`: Control plane simulator to setup tenants configuration.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- MongoDB or MySQL instance
- Visual Studio 2022

### Configuration

Edit `ControlPlaneInMemoryRepository` to configure and test your database connections. But, replace it with your own control plane integration.

> If you are using windows, configure your hosts file to use the following names:
- 127.0.0.1 company1.localhost.com
- 127.0.0.1 company2.localhost.com
- 127.0.0.1 company3.localhost.com

### Run the web API

Access the addresses and check what is going to happen:

- `Company1` - Will try to access MongoDb Users collection 
- `Company2` - Will try to access mysql database and query users table
- `Company3` - As it is not configured, it will return an Forbiden response 
