using csv_parser.Interfaces;
using csv_parser.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace csv_parser.Common;

public class DiExtension
{
    public static ServiceProvider CreateServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICsvWriterService, CsvWriterService>()
            .AddSingleton<ICsvParser, CsvParser>()
            .AddSingleton<ISqlBulkInserter, SqlBulkInserter>()
            .BuildServiceProvider();

        return serviceProvider;
    }

    public static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true);

        return builder.Build();
    }
}