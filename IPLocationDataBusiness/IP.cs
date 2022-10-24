using IPLocationData_Data.Models;
using System.Net;

namespace IPLocationDataBusiness
{
    public class IP
    {
        static readonly HttpClient client = new();
        public async Task<WhoIs> GetIPLocationAsync(string ip)
        {
            WhoIs whoisData = new();

            HttpResponseMessage response = await client.GetAsync("http://ipwho.is/" + ip + "?fields=country,country_code,city,region,latitude,longitude");

            if (response.IsSuccessStatusCode)
            {

                whoisData = await response.Content.ReadAsAsync<WhoIs>();

            }

            return whoisData;
        }

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
    }
}
