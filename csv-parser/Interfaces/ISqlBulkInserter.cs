using csv_parser.Models;

namespace csv_parser.Interfaces;

public interface ISqlBulkInserter
{
    Task BulkInsertAsync(IEnumerable<CsvRecord> records, string connectionString);
}