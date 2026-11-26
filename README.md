# StoreManager

StoreManager is a C# application for managing products, stores and product categories. The project is built to practise object-oriented programming, Entity Framework Core and database relationships.

## Features

- **Product management** – Manage products and their information.
- **Store management** – Organise products by store.
- **Category management** – Group products into categories.
- **Price information** – Display product prices and calculate average prices.
- **Database management** – Store and retrieve data using Entity Framework Core.

## Technologies

- C#
- .NET
- Entity Framework Core
- Entity Framework Core Migrations
- SQL Database

## Project Structure

The solution is divided into several layers:

| Project | Description |
|---|---|
| `StoreManager.BL` | Contains the domain classes and business logic. |
| `StoreManager.DAL` | Contains the data access interfaces and database operations. |
| `StoreManager.DAL.EF` | Implements data access using Entity Framework Core. |
| `StoreManager.UI.CA` | Console application used to interact with the application. |

## Getting Started

### Prerequisites

- .NET SDK
- An IDE such as JetBrains Rider or Visual Studio
- A configured database

### Running the application

1. Clone the repository:

   ```bash
   git clone https://github.com/Idragg/StoreManager.git
   ```

2. Open the solution in your IDE.

3. Configure the database connection string.

4. Apply the Entity Framework Core migrations if necessary.

5. Run the `StoreManager.UI.CA` project.

## Purpose

This project is part of my learning process in C# development. It focuses on understanding object-oriented programming, working with relational databases and implementing Entity Framework Core in a layered application architecture.

---

*This project is a learning project and is still under development.*