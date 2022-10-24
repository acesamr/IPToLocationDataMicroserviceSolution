namespace IPLocationData_Data.Models
{
    public class CurrencyExchange
    {
        public string? Base_Currency_Code { get; set; }
        public string? Base_Currency_Name { get; set; }
        public decimal? Amount { get; set; }
        public string? Updated_Date { get; set; }
        public Rate? Rates { get; set; }
        public string? Status { get; set; }
    }

    public class Rate
    {
        public GBP? GBP { get; set; }
    }

    public class GBP
    {
        public string? Currency_Name { get; set; }
        public string? Rate { get; set; }
        public string? Rate_For_Amount { get; set; }
    }
}
