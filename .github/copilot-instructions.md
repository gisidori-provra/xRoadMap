# xRoadMap23 - Road Infrastructure Management System

xRoadMap23 is a Windows desktop application built with DevExpress XAF (eXpressApp Framework) for managing road infrastructure including roads, bridges, tunnels, lighting systems, vegetation and street furniture. The system integrates with Oracle spatial databases for comprehensive infrastructure monitoring and reporting.

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

## Critical Build Requirements

⚠️ **WINDOWS ONLY**: This application CANNOT be built or run on Linux/macOS. It requires Windows with proper DevExpress licensing.

## Key Dependencies

### DevExpress Packages (v24.2.7)
- DevExpress.ExpressApp.ConditionalAppearance
- DevExpress.ExpressApp.Security.Xpo
- DevExpress.ExpressApp.Validation.Win
- DevExpress.ExpressApp.ViewVariantsModule
- DevExpress.Persistent.BaseImpl.Xpo
- DevExpress.Win.Map
- DevExpress.Data.Desktop

### NuGet Packages (Public)
- Oracle.ManagedDataAccess (23.8.0)
- NetTopologySuite (2.5.0)
- GeoAPI.Core (1.7.5)
- System.Text.Json (6.0.1)

### System Requirements
- **Visual Studio 2017 or later** (Community, Professional, or Enterprise)
- **.NET Framework 4.8 Developer Pack**
- **DevExpress Universal subscription v24.2.7** (commercial license required)
- **Oracle Data Access Components** (for database connectivity)

### Why Build Fails on Linux
- DevExpress packages require valid commercial license and are not available on public NuGet
- .NET Framework 4.8 targeting pack not available on Linux
- Oracle SDE connectivity requires Windows-specific components

## Working Effectively (Windows Environment)

### Initial Setup
1. **Install DevExpress v24.2.7**:
   - Ensure DevExpress Universal subscription is active
   - Register DevExpress assemblies in GAC if prompted
   - Verify license is properly activated

2. **Configure Database Connection**:
   - Update connection strings in `App.config` files
   - Ensure Oracle database with spatial extensions is accessible
   - Test connection with provided credentials

3. **Build Main Application**:
   ```batch
   # Open Visual Studio and load solution
   # File -> Open -> Project/Solution -> xRoadMap23.sln
   # Build -> Build Solution (Ctrl+Shift+B)
   
   # Alternative: MSBuild command line
   msbuild xRoadMap23.sln /p:Configuration=Release
   ```
   **TIMING**: Build takes 3-5 minutes. NEVER CANCEL builds - always wait for completion.

4. **Build Sync Utilities**:
   ```batch
   msbuild SyncAppostamenti.sln /p:Configuration=Release
   ```
   **TIMING**: Sync build takes 1-2 minutes. NEVER CANCEL builds.

## Running the Application

### Main Application
1. Set `xRoadMap23.Win` as startup project
2. Configure connection string in `xRoadMap23.Win/App.config`:
   ```xml
   <connectionStrings>
     <add name="ConnectionString" 
          connectionString="XpoProvider=OracleSDE;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=your_host)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=your_service)));User ID=your_user;Password=your_password" 
          providerName="Oracle.ManagedDataAccess.Client" />
   </connectionStrings>
   ```
3. Press F5 to run or build and execute the executable

### Command Line Sync Tool
- Build `SyncAppostamenti.sln` for data synchronization utilities
- Use `SyncAppCmd.exe` for command line operations:
  ```batch
  SyncAppCmd.exe synch    # Synchronize both databases
  SyncAppCmd.exe load     # Load data from appointments database  
  SyncAppCmd.exe update   # Update SDE feature classes
  ```

## Project Structure and Navigation

### Main Solution (xRoadMap23.sln)
```
├── xRoadMap23.Module/                # Core business logic and data model
│   ├── BusinessObjects/              # Domain entities (roads, bridges, etc.)
│   │   ├── RoadDataModel/           # Road infrastructure entities
│   │   └── cspraDataModel/          # Province-specific extensions
│   ├── Controllers/                 # Business logic controllers
│   └── DatabaseUpdate/             # Database migration scripts
├── xRoadMap23.Module.Win/           # Windows UI specific modules  
├── xRoadMap23.Win/                  # Main Windows Forms application
└── xRoadMap23.cspra.Module/         # Province-specific extensions
```

### Sync Solution (SyncAppostamenti.sln)
```
├── SyncAppostamenti/                # Main sync application
├── SyncAppCmd/                      # Command line sync tool
└── SyncModule/                      # Core synchronization framework
```

### Utilities
```
└── ImportTransiti/                  # Traffic data import utilities
```

## Key Business Objects

The system manages comprehensive road infrastructure entities:

- **Strada**: Road segments and properties
- **Ponte**: Bridge structures and specifications  
- **Galleria**: Tunnel infrastructure
- **Illuminazione**: Street lighting systems
- **Vegetazione**: Road vegetation management
- **Tombino**: Utility access points
- **Ordinanza**: Municipal regulations
- **Ispezione**: Infrastructure inspection records

## Database Configuration

The application requires Oracle database with spatial extensions. Configure connection in `App.config`:

```xml
<connectionStrings>
  <add name="ConnectionString" 
       connectionString="XpoProvider=OracleSDE;Data Source=your_oracle_server;User ID=xMap;Password=xMap" 
       providerName="Oracle.ManagedDataAccess.Client" />
</connectionStrings>
```

## Testing and Validation

### Manual Validation Steps
After making changes, ALWAYS validate through complete user scenarios:

1. **Application Startup**: Verify application starts without errors and connects to database
2. **Navigation Test**: Navigate through main modules (Roads, Bridges, Inspections) 
3. **Data Entry Test**: Create a new road segment with basic properties
4. **Search/Filter Test**: Use search and filtering functionality
5. **Report Generation**: Generate at least one infrastructure report
6. **Sync Tool Test**: Run `SyncAppCmd.exe synch` and verify completion

### Build Validation
- Always run full rebuild before committing changes
- Test both Debug and Release configurations
- Verify all projects build without warnings

## Common Development Tasks

### Adding New Business Objects
1. Add entity class to `xRoadMap23.Module/BusinessObjects/`
2. Implement required XAF attributes and relationships
3. Update database schema through XAF database update mechanism
4. Add any custom controllers in `Controllers/` folder

### Modifying UI
1. Windows Forms customizations go in `xRoadMap23.Module.Win/`
2. Use XAF Model Editor to modify application model
3. Custom controls and editors in respective folders

### Database Changes
1. Business object changes automatically trigger schema updates
2. Manual scripts can be added to `DatabaseUpdate/` folder
3. Test database updates in development environment first

## Important Files to Check When Making Changes

- **Always check** `xRoadMap23.Module/BusinessObjects/` when modifying data model
- **Always check** `App.config` files when changing database connectivity
- **Always check** `Controllers/` folders when modifying business logic
- **Always check** `xRoadMap23.Win/Program.cs` when modifying application startup
- **Always check** connection string configuration in multiple App.config files
- **Always verify** solution builds completely after any changes

## Common Errors and Solutions

### Build Errors
- **NU1101 DevExpress package errors**: Ensure DevExpress license is properly installed and activated
- **MSB3644 .NET Framework reference errors**: Install .NET Framework 4.8 Developer Pack
- **Oracle connection errors**: Verify Oracle Data Access Components are installed

### Runtime Errors
- **Connection string errors**: Check Oracle database accessibility and credentials
- **DevExpress license errors**: Verify runtime license is properly configured
- **XAF model errors**: Use Model Editor to validate application model

## Known Limitations

- **Windows Only**: Cannot build or run on Linux/macOS
- **DevExpress License Required**: Cannot build without valid commercial license
- **Oracle Database Required**: Application requires Oracle with spatial extensions
- **No Automated Tests**: Manual validation is required for all changes

## Time Expectations

- **Full Build**: 3-5 minutes (NEVER CANCEL)
- **Sync Build**: 1-2 minutes (NEVER CANCEL)  
- **Application Startup**: 30-60 seconds (depending on database connection)
- **Manual Validation**: 10-15 minutes for complete scenario testing

## Support Information

- **Organization**: Provincia di Ravenna
- **Application Version**: xRoadMap v1.0.0.47
- **Framework**: DevExpress XAF 24.2.7
- **Target Framework**: .NET Framework 4.8