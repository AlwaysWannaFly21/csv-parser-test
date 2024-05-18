using System.Data;
using System.Data.SqlClient;
using csv_parser.Interfaces;
using csv_parser.Models;

namespace csv_parser.Services;

public class SqlBulkInserter : ISqlBulkInserter
{
    public const int BatchSize = 5000;
    public const string DestinationTableName = "dbo.TaxiTrips";

    public async Task BulkInsertAsync(IEnumerable<CsvRecord> records, string connectionString)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        using var bulkCopy = new SqlBulkCopy(connection)
        {
            DestinationTableName = DestinationTableName,
            BatchSize = BatchSize
        };

        var dataTable = new DataTable();
        dataTable.Columns.Add("Id", typeof(int));
        dataTable.Columns.Add("TpepPickupDatetime", typeof(DateTime));
        dataTable.Columns.Add("TpepDropoffDatetime", typeof(DateTime));
        dataTable.Columns.Add("PassengerCount", typeof(int));
        dataTable.Columns.Add("TripDistance", typeof(decimal));
        dataTable.Columns.Add("StoreAndFwdFlag", typeof(string));
        dataTable.Columns.Add("PULocationID", typeof(int));
        dataTable.Columns.Add("DOLocationID", typeof(int));
        dataTable.Columns.Add("FareAmount", typeof(decimal));
        dataTable.Columns.Add("TipAmount", typeof(decimal));

        foreach (var csvRecord in records)
            dataTable.Rows.Add(default,
                csvRecord.TpepPickupDatetime,
                csvRecord.TpepDropoffDatetime,
                csvRecord.PassengerCount,
                csvRecord.TripDistance,
                csvRecord.StoreAndFwdFlag,
                csvRecord.PULocationID,
                csvRecord.DOLocationID,
                csvRecord.FareAmount,
                csvRecord.TipAmount
            );

        await bulkCopy.WriteToServerAsync(dataTable);
        await connection.CloseAsync();
    }
}