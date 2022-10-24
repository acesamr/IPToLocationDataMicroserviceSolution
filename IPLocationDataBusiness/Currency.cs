using IPLocationData_Data.Models;
using Newtonsoft.Json;

namespace IPLocationDataBusiness
{
    public class Currency
    {
        static readonly HttpClient client = new();
        public async Task<string> GetCountryCodeToCurrencyCode(string country_code)
        {
            CurrencyCode currencyCode = new();

            HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v2/alpha?codes=" + country_code);

            if (response.IsSuccessStatusCode)
            {

                string json = await response.Content.ReadAsStringAsync();

                json = json.TrimStart('[');

                json = json.TrimEnd(']');

                currencyCode = JsonConvert.DeserializeObject<CurrencyCode>(json);

            }

            return currencyCode.Currencies.First().Code;
        }


        public async Task<CurrencyExchange> GetCurrencyConversionAsync(string country_code)
        {
            CurrencyExchange exchangeRate = null;

            HttpResponseMessage response = await client.GetAsync("https://api.getgeoapi.com/v2/currency/convert?api_key=0f7cd9d7b2e6710a424ddf7efb29edacb1eda7a8&from=" + country_code + "&to=GBP&amount=1&format=json");

            if (response.IsSuccessStatusCode)
            {

                exchangeRate = await response.Content.ReadAsAsync<CurrencyExchange>();

            }

            return exchangeRate;
        }
    }
}
