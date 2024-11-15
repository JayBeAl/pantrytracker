# PantryTracker

A modern web application to manage your food inventory with barcode scanning capabilities.

## Features

- Dashboard with inventory overview
- Food item management (CRUD operations)
- Barcode scanning using device camera
- Open Food Facts API integration (coming soon)
- Shopping list generation (planned)

## Tech Stack

- ASP.NET Core 8.0
- Blazor Server
- Entity Framework Core
- SQLite Database
- JavaScript (ZXing for barcode scanning)

## Getting Started

1. Prerequisites
    - .NET 8.0 SDK
    - Node.js and npm

2. Installation
   ```bash
   git clone https://github.com/yourusername/PantryTracker.git
   cd PantryTracker
   dotnet restore
   cd PantryTracker.Web
   npm install
   ```
3. Run the application 
   ```bash
   dotnet run
   ```

## Development
- Database migrations: dotnet ef migrations add [MigrationName]
- Update database: dotnet ef database update
- JavaScript bundling is automatic during build
  Roadmap
  See our ToDo List for planned features and enhancements.

## Roadmap
See our [ToDo](TODO.md) List for planned features and enhancements.

## License
MIT License