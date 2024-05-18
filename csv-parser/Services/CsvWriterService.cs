using System.Globalization;
using csv_parser.Interfaces;
using csv_parser.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace csv_parser.Services;

public class CsvWriterService : ICsvWriterService
{
    public Task WriteDuplicatesToCsv(IEnumerable<CsvRecord> duplicateRecords, string filePath)
    {
        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));

        csv.WriteHeader<CsvRecord>();
        csv.NextRecord();

        csv.WriteRecordsAsync(duplicateRecords);
        csv.NextRecord();

        return Task.CompletedTask;
    }
}