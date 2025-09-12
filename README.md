# xRoadMap23

A comprehensive road infrastructure management system developed for the Province of Ravenna, Italy. This application provides tools for managing, tracking, and maintaining road networks and associated infrastructure.

## 🚗 Overview

xRoadMap23 is a Windows desktop application built with the DevExpress XAF (eXpressApp Framework) that enables efficient management of road infrastructure including roads, bridges, tunnels, lighting systems, vegetation, and various road furniture. The system integrates with spatial databases and provides comprehensive tools for infrastructure monitoring and reporting.

## ✨ Key Features

- **Road Network Management**: Complete management of road segments, intersections, and routing
- **Infrastructure Tracking**: Monitor bridges, tunnels, lighting, vegetation, and other road furniture
- **Spatial Data Integration**: GIS capabilities with spatial database support (Oracle SDE)
- **Ordinance Management**: Track and manage municipal ordinances affecting road infrastructure
- **Inspection System**: Schedule and record infrastructure inspections
- **Synchronization Tools**: Utilities for data synchronization and import/export
- **Multi-Module Architecture**: Modular design for extensibility and maintenance

## 🛠️ Technology Stack

- **.NET Framework 4.8**: Core application framework
- **DevExpress XAF**: Enterprise application framework
- **DevExpress Controls**: Rich UI components (v24.2.7)
- **Oracle Database**: Primary data storage with spatial extensions
- **NetTopologySuite**: Spatial geometry processing
- **Windows Forms**: Desktop UI framework

## 📋 System Requirements

### Development Environment
- **Visual Studio 2017 or later**
- **.NET Framework 4.8 Developer Pack**
- **DevExpress Controls v24.2.7** (license required)
- **Oracle Data Access Components**

### Runtime Environment
- **Windows 10 or later**
- **.NET Framework 4.8 Runtime**
- **Oracle Client** (for database connectivity)
- **Minimum 4GB RAM**
- **100MB+ available disk space**

## 🏗️ Project Structure

```
xRoadMap/
├── xRoadMap23.sln                    # Main solution file
├── SyncAppostamenti.sln              # Synchronization solution
├── xRoadMap23.Module/                # Core business logic and data model
│   ├── BusinessObjects/              # Domain entities (roads, bridges, etc.)
│   ├── Controllers/                  # Business logic controllers
│   └── DatabaseUpdate/               # Database migration scripts
├── xRoadMap23.Module.Win/            # Windows-specific UI modules
├── xRoadMap23.Win/                   # Main Windows Forms application
├── xRoadMap23.cspra.Module/          # Province-specific extensions
├── SyncAppostamenti/                 # Data synchronization utility
├── SyncAppCmd/                       # Command-line sync tool
├── SyncModule/                       # Synchronization module
└── ImportTransiti/                   # Traffic data import utility
```

## 🚀 Getting Started

### Building the Application

1. **Clone the repository**:
   ```bash
   git clone https://github.com/GIsidori/xRoadMap.git
   cd xRoadMap
   ```

2. **Install DevExpress Components**:
   - Ensure DevExpress Universal subscription v24.2.7 is installed
   - Register DevExpress assemblies in GAC if required

3. **Configure Database Connection**:
   - Update connection strings in `App.config` files
   - Ensure Oracle database is accessible
   - Run database update scripts if needed

4. **Build the Solution**:
   ```bash
   # Using Visual Studio
   Open xRoadMap23.sln in Visual Studio
   Build -> Build Solution (Ctrl+Shift+B)

   # Using MSBuild
   msbuild xRoadMap23.sln /p:Configuration=Release
   ```

### Running the Application

1. **Main Application**:
   - Set `xRoadMap23.Win` as startup project
   - Configure connection string in `App.config`
   - Press F5 to run or build and run the executable

2. **Synchronization Tools**:
   - Build `SyncAppostamenti.sln` for data sync utilities
   - Use `SyncAppCmd` for command-line operations

## 🗃️ Database Configuration

The application requires an Oracle database with spatial extensions. Configure the connection string in the application's `App.config` file:

```xml
<connectionStrings>
    <add name="ConnectionString" 
         connectionString="Data Source=your_server;User Id=your_user;Password=your_password;" 
         providerName="Oracle.ManagedDataAccess.Client" />
</connectionStrings>
```

## 📊 Main Entities

The system manages various road infrastructure entities:

- **Strada** (Roads): Main road segments and properties
- **Ponte** (Bridges): Bridge structures and specifications
- **Galleria** (Tunnels): Tunnel infrastructure
- **Illuminazione** (Lighting): Street lighting systems
- **Vegetazione** (Vegetation): Roadside vegetation management
- **Tombino** (Manholes): Utility access points
- **Ordinanza** (Ordinances): Municipal regulations
- **Ispezione** (Inspections): Infrastructure inspection records

## 🔧 Development

### Adding New Features

1. **Business Objects**: Add new entities in `xRoadMap23.Module/BusinessObjects/`
2. **Controllers**: Implement business logic in appropriate controller classes
3. **UI Customization**: Extend Windows forms in `xRoadMap23.Module.Win/`
4. **Database Changes**: Update schema through XAF's database update mechanism

### Code Style

- Follow Microsoft C# coding conventions
- Use meaningful names for classes and methods
- Document public APIs with XML comments
- Implement proper error handling and logging

## 🤝 Contributing

This project is maintained by the Province of Ravenna. For contributions:

1. Fork the repository
2. Create a feature branch
3. Implement changes with appropriate tests
4. Submit a pull request with detailed description

## 📄 License

This project is proprietary software developed for the Province of Ravenna. Please contact the development team for licensing information.

## 📞 Support

For technical support or questions:

- **Organization**: Provincia di Ravenna
- **Application**: xRoadMap v1.0.0.47
- **Framework**: DevExpress XAF

## 🗺️ Related Projects

- **ImportTransiti**: Traffic data import utility
- **SyncAppostamenti**: Data synchronization tools
- **SyncModule**: Core synchronization framework

---

*This application is part of the digital infrastructure initiative of the Province of Ravenna for efficient road network management and maintenance.*