using Microsoft.AspNetCore.Mvc;
using IPLocationDataBusiness;
using IPLocationData_Data.Models;
using Newtonsoft.Json;
using IPLocationDataWebAPI.ViewModel;

namespace IPLocationDataWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationDataController : ControllerBase
    {
        /// <summary>
        /// Get Location Data Via IP Address
        /// </summary>
        /// <param name="ip"></param>
        /// <returns>Returns the Location Name, Temperature and Currency Exchange Rate to GBP</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/LocationData/5.45.98.97
        ///
        /// </remarks>
        /// <response code="201">
        /// Return Data: 
        /// {
        ///   "locationName": "Baden-Württemberg Karlsruhe, Germany",
        ///   "temperature": "15.4°C | 59.7°F",
        ///   "gbpExchangeRate": "1 EUR = 0.8675GBP"
        /// }
        /// 
        /// </response>
        /// <response code="400">If the IP address is invalid.</response>
        [HttpGet("{ip}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LocationDataViewModel>> GetLocationDataViaIP(string ip)
        {
            IP ipClass = new();
            if(!ipClass.ValidateIPv4(ip))
            {
                return BadRequest();
            }

            Information information = new();

            LocationData locationData = await information.GetLocationDataAsync(ip);

            LocationDataViewModel locationDataView = new LocationDataViewModel
            {
                LocationName = locationData.LocationName,
                Temperature = locationData.Temperature,
                GBPExchangeRate = locationData.GBPExchangeRate
            };

            return Ok(locationDataView);

        }
        
    }
}
