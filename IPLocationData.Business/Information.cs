using IPLocationData_Data.Models;

namespace IPLocationDataBusiness
{
    public class Information
    {
        public async Task<LocationData> GetLocationDataAsync(string ip)
        {
            Currency currency = new();

            IP ipInfo = new();

            CountryWeather countryWeather = new CountryWeather();

            WhoIs location = await ipInfo.GetIPLocationAsync(ip);

            Weather weather = await countryWeather.GetWeatherAsync(location.Longitude, location.Latitude);

            string currencyCode = await currency.GetCountryCodeToCurrencyCode(location.Country_Code);

            CurrencyExchange currencyExchange = await currency.GetCurrencyConversionAsync(currencyCode);

            LocationData locationData = new()
            {
                LocationName = location.Region + " " + location.City + ", " + location.Country,
                Temperature = weather.Current.Temp_C + "°C | " + weather.Current.Temp_F + "°F",
                GBPExchangeRate = "1 " + currencyCode + " = " + currencyExchange.Rates.GBP.Rate + "GBP"
            };

            return locationData;
        }
    }
}
