using IPLocationData_Data.Models;

namespace IPLocationDataBusiness
{
    public class CountryWeather
    {
        static HttpClient client = new();
        public async Task<Weather> GetWeatherAsync(string longitude, string latitude)
        {
            Weather weatherData = new();

            HttpResponseMessage response = await client.GetAsync("http://api.weatherapi.com/v1/current.json?key=1e03ac7e625b41dda93161208222310&q=" + latitude + "," + longitude + "&aqi=no");

            if (response.IsSuccessStatusCode)
            {

                weatherData = await response.Content.ReadAsAsync<Weather>();

            }

            return weatherData;
        }
    }
}
