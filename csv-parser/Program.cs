using csv_parser.Common;
using csv_parser.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var config = DiExtension.BuildConfiguration();
var serviceProvider = DiExtension.CreateServices();

var connectionString = config.GetSection("environmentVariables:ConnectionString").Value!;
var csvUrl = config.GetSection("environmentVariables:csvUrl").Value!;
var duplicateFilePath = config.GetSection("environmentVariables:duplicateFilePath").Value!;

var csvWriter = serviceProvider.GetRequiredService<ICsvWriterService>();
var csvParser = serviceProvider.GetRequiredService<ICsvParser>();
var sqlBulkInserter = serviceProvider.GetRequiredService<ISqlBulkInserter>();

var (validRecords, duplicateRecords) = csvParser.ParseCsvData(csvUrl);

var writeDuplicatesTask = csvWriter.WriteDuplicatesToCsv(duplicateRecords, duplicateFilePath);
var bulkInsertTask = sqlBulkInserter.BulkInsertAsync(validRecords, connectionString);

await Task.WhenAll(writeDuplicatesTask, bulkInsertTask);