namespace csv_parser.Models;

public class CsvRecord
{
    public DateTime TpepPickupDatetime { get; set; }
    public DateTime TpepDropoffDatetime { get; set; }
    public int PassengerCount { get; set; }
    public decimal TripDistance { get; set; }
    public string StoreAndFwdFlag { get; set; }
    public int PULocationID { get; set; }
    public int DOLocationID { get; set; }
    public decimal FareAmount { get; set; }
    public decimal TipAmount { get; set; }

    public bool Equals(CsvRecord? other)
    {
        if (other is null)
            return false;

        return TpepPickupDatetime == other.TpepPickupDatetime &&
               TpepDropoffDatetime == other.TpepDropoffDatetime &&
               PassengerCount == other.PassengerCount;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as CsvRecord);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TpepPickupDatetime, TpepDropoffDatetime, PassengerCount);
    }
}