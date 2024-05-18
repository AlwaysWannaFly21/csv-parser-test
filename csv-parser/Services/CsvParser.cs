using System.Globalization;
using csv_parser.Helpers;
using csv_parser.Interfaces;
using csv_parser.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace csv_parser.Services;

public class CsvParser : ICsvParser
{
    public (List<CsvRecord> ValidRecords, List<CsvRecord> DuplicateRecords) ParseCsvData(string csvPath)
    {
        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null,
            BadDataFound = null
        });

        var records = new List<CsvRecord>();
        var duplicates = new List<CsvRecord>();

        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            var record = new CsvRecord
            {
                TpepPickupDatetime =  CsvConverterHelper.TryParseField(csv, CsvFieldConstants.TpepPickupDatetime, DateTime.MinValue),
                TpepDropoffDatetime = CsvConverterHelper.TryParseField(csv, CsvFieldConstants.TpepDropoffDatetime, DateTime.MinValue),
                PassengerCount =      CsvConverterHelper.TryParseField(csv, CsvFieldConstants.PassengerCount, 0),
                TripDistance =        CsvConverterHelper.TryParseField(csv, CsvFieldConstants.TripDistance, decimal.Zero),
                StoreAndFwdFlag =     CsvConverterHelper.TrimAndConvertStoreAndFwdFlag(
                                         CsvConverterHelper.TryParseField(csv, CsvFieldConstants.StoreAndFwdFlag, string.Empty)),
                PULocationID =        CsvConverterHelper.TryParseField(csv, CsvFieldConstants.PULocationID, 0),
                DOLocationID =        CsvConverterHelper.TryParseField(csv, CsvFieldConstants.DOLocationID, 0),
                FareAmount =          CsvConverterHelper.TryParseField(csv, CsvFieldConstants.FareAmount, decimal.Zero),
                TipAmount =           CsvConverterHelper.TryParseField(csv, CsvFieldConstants.TipAmount, decimal.Zero)
            };

            if (records.Contains(record))
                duplicates.Add(record);
            else
                records.Add(record);
        }

        return (records, duplicates);
    }
}