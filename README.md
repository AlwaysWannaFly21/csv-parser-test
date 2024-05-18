# CSV Parser Project Documentation

### **Overview**

This project is designed to parse CSV files containing taxi trip data, identify and handle duplicate records, and bulk insert the valid records into an MS SQL database. The project leverages dependency injection for service management and follows best practices for configuration and error handling.

### **Project Structure**

- **Common**: Contains common utilities and the DI (Dependency Injection) extension.
- **Helpers**: Provides helper methods for CSV parsing.
- **Interfaces**: Defines the interfaces for services used in the project.
- **Models**: Contains the data models.
- **Services**: Implements the services for CSV parsing, writing, and database operations.

### **Dependencies**

- CsvHelper
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.DependencyInjection
- System.Data.SqlClient

### **Configuration**

The project expects a configuration file **`appsettings.json`** with the following structure:

```jsx
{
  "environmentVariables": {
    "ConnectionString": "your-database-connection-string",
    "csvUrl": "path-to-your-csv-file",
    "duplicateFilePath": "path-to-save-duplicates.csv"
  }
}
```

### **SQL Table Creation**

The table was created by this command:

```sql
CREATE TABLE TaxiTrips (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TpepPickupDatetime DATETIME NOT NULL,
    TpepDropoffDatetime DATETIME NOT NULL,
    PassengerCount INT NOT NULL,
    TripDistance DECIMAL(10, 2) NOT NULL,
    StoreAndFwdFlag NVARCHAR(3) NOT NULL,
    PULocationID INT NOT NULL,
    DOLocationID INT NOT NULL,
    FareAmount DECIMAL(10, 2) NOT NULL,
    TipAmount DECIMAL(10, 2) NOT NULL
);
```

### To run a project

### **Running the Project**

1. Ensure **`appsettings.json`** is properly configured.
2. Place a csv file at bin → Debug → .NET8.
3. I will send a connectionString in a mail.
4. Build the project. (or use a docker)
5. Run the project.
