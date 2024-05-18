using csv_parser.Models;

namespace csv_parser.Interfaces;

public interface ICsvWriterService
{
    Task WriteDuplicatesToCsv(IEnumerable<CsvRecord> duplicateRecords, string filePath);
}