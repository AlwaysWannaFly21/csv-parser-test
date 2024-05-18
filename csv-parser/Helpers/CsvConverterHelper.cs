using CsvHelper;

namespace csv_parser.Helpers;

public static class CsvConverterHelper
{
    public static string TrimAndConvertStoreAndFwdFlag(string flag)
    {
        return flag.Trim() switch
        {
            "N" => "No",
            "Y" => "Yes",
            _ => flag.Trim()
        };
    }

    public static T TryParseField<T>(CsvReader csvReader, string fieldName, T defaultValue)
    {
        return csvReader.TryGetField<T>(fieldName, out var value) ? value : defaultValue;
    }
}