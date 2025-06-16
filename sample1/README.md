# .NET 5 Web API with Azure Connection

This project is a basic ASP.NET Core Web API targeting .NET 5.0. It is ready to be extended for Azure services integration (e.g., Azure SQL, Blob Storage, etc.).

## Getting Started

1. **Restore dependencies:**
   ```powershell
   dotnet restore
   ```
2. **Build the project:**
   ```powershell
   dotnet build
   ```
3. **Run the API:**
   ```powershell
   dotnet run
   ```

## Azure Integration
- To connect to Azure services, add the relevant NuGet packages (e.g., `Microsoft.Azure.*`).
- Configure your Azure connection strings in `appsettings.json` or use Azure Key Vault for secrets management.

## Notes
- .NET 5 is out of support. Consider upgrading to a supported version for production use.
