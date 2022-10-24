using IPDataWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IPDataWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPToDataController : ControllerBase
    {
        // GET: api/<IPToDataController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IPToDataController>/5
        [HttpGet("{ip}")]
        public string Get(string ip)
        {
            LocationData locationData = new LocationData();
            GetWhoIsData(ip);
            return "value";
        }

        // POST api/<IPToDataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IPToDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IPToDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public async Task<WhoIsData> GetWhoIsData(string ipAddress)
        {
            //Define your baseUrl
            string baseUrl = "http://ipwho.is/" + ipAddress + "?fields=country_code,currency";


            using HttpClient client = new();

            using HttpResponseMessage res = await client.GetAsync(baseUrl);

            using HttpContent content = res.Content;

            var data = await content.ReadAsStringAsync();

            WhoIsData whoisdata = JsonConvert.DeserializeObject<WhoIsData>(data);

            return whoisdata;

        }
    }
}
