# Dashboard Mock-Up Application

A Blazor Server application featuring a dynamic dashboard with country, brand, and location selection capabilities using Telerik UI components.

## Features

- Interactive dashboard interface
- Cascading dropdowns for:
  - Countries
  - Brands (filtered by country)
  - Locations (filtered by country)
- RESTful API endpoints for data retrieval
- Modern UI with Telerik UI for Blazor components
- CORS support for API access

## Prerequisites

- .NET 7.0 SDK or later
- Visual Studio 2022 or later (recommended)
- Telerik UI for Blazor Trial License

## Dependencies

- Microsoft.AspNetCore.StaticFiles (2.3.0)
- Swashbuckle.AspNetCore (7.0.0)
- Telerik.DataSource.Trial (3.0.3)
- Telerik.UI.for.Blazor.Trial (8.1.1)

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Build and run the application

The application will start on `https://localhost:7145` by default.

## API Endpoints

The application exposes the following API endpoints:

- `GET /api/countries` - Returns list of all countries
- `GET /api/brands/{countryId}` - Returns brands for a specific country
- `GET /api/locations/{countryId}` - Returns locations for a specific country

Example response for `/api/countries`:
```json
[
  {
    "id": "ZA",
    "name": "South Africa"
  },
  {
    "id": "US",
    "name": "United States"
  }
  // ... other countries
]
```

## Project Structure

- `Program.cs` - Application entry point and configuration
- `Data/` - Data providers and services
- `Models/` - Data models (Country, Brand, Location)
- `Pages/` - Blazor pages
- `Shared/` - Shared components including TopNavBar
- `wwwroot/` - Static files

## Configuration

The application uses the following configuration in `Program.cs`:
- Blazor Server
- API Controllers
- Swagger/OpenAPI
- CORS (Cross-Origin Resource Sharing)
- HTTP Client
- Telerik UI services

## Development

To run the application in development mode:

1. Set the environment to "Development"
2. Run the application
3. Access Swagger UI at `/swagger` for API documentation
4. Use browser developer tools for debugging

## Known Issues

- Telerik UI Trial version will show license notifications
- A script is included to automatically close these notifications

## License

This project uses Telerik UI for Blazor Trial License. 
