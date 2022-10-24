namespace IPLocationData_Data.Models
{
    public class CurrencyCode
    {
        public List<Currencies>? Currencies { get; set; }
    }

    public class Currencies
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
    }
}
