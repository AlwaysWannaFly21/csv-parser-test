using csv_parser.Models;

namespace csv_parser.Interfaces;

public interface ICsvParser
{
    public (List<CsvRecord> ValidRecords, List<CsvRecord> DuplicateRecords) ParseCsvData(string csvPath);
}