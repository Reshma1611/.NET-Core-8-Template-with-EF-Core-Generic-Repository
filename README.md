# .NET Core 8 Template with EF Core & Generic Repository

## Overview

This repository provides a template for building .NET Core 8 applications using **MS SQL Server** and **Entity Framework Core**. It follows a structured architecture with:  

- **Generic Repository Pattern** for database operations  
- **Generic Service Interface** to promote modularity  
- **Consistent API Responses** with a standardized response format  
- **Custom Middleware** for handling exceptions, logging, and request validation  





## Features

- .NET Core 8 as the backend framework
- MS SQL Server as the database
- Entity Framework Core for ORM
- Generic Repository Pattern for database operations
- Generic Service Interface to maintain a scalable architecture

## Project Structure  
```plaintext
/Template.API  
│── /Template.API  
│   ├── /Controllers
│   ├── /Core
|       ├── AppCommon.cs
|       ├── ExceptionMiddleware.cs
|       ├── FieldError.cs
|       ├── InvalidModelStateHandler.cs
|       ├── LoggingMiddleware.cs
|       ├── ResponseData.cs
│── /Template.BL  
│   ├── /DTOModels  
│   ├── /Repositories
|       ├── GenericRepository.cs
|       ├── IGenericInterface.cs
|       ├── IGenericRepository.cs
│   ├── /Services
|       ├── InventoryService.cs
|       ├── ItemService.cs
│── /Template.DL
│   ├── /DBModels
```

## Getting Started

### Prerequisites
Before you begin, ensure you have the following installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [MS SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)

### Setup  
Follow these steps to set up and run the project:


**1. Clone the repository**  
```sh
   git clone https://github.com/Reshma1611/.NET-Core-8-Template-with-EF-Core-Generic-Repository.git
```

**2. Configure the database connection**
   - Open appsettings.json of Template.API Project
   - Update the connection string to match your SQL Server setup

**3. Apply database migrations**  
```sh
   update-database
```
**4. Run the application**  
