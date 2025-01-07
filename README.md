# Pokemon API

## Overview

The Pokemon API project is a Web API built using ASP.NET Core. It provides endpoints to manage a collection of Pokemon, including creating, retrieving, updating, and deleting Pokemon records. The project is structured with a clean architecture and follows best practices for Web API development.

## Features

- CRUD (Create, Read, Update, Delete) operations for managing Pokemon.

- Follows RESTful API principles.

- Configurable database connection.

- Includes models, controllers, and a database context for structured development.

## Prerequisites

Ensure you have the following installed on your system:

- .NET SDK (version 6.0 or higher)

- Visual Studio or another IDE with C# support

- SQL Server (optional if using SQL for database)

## Step-by-Step Guide

### 1. Create a New ASP.NET Core Web API Project

### 2. Configure the Database
- Open the appsettings.json file.
- Locate the ConnectionStrings section and update it to match your database configuration:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=PokemonDB;Trusted_Connection=True"
  }
}
```

