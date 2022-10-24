using IPLocationDataWebAPI.Controllers;
using IPLocationDataWebAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Principal;

namespace IPLocationData.Tests
{
    public class IPLocationDataTests
    {
        static string ip = "5.45.98.97";

        static LocationDataController controller = new();

        [Fact]
        public async Task GetLocationDataViaIP_Returns_Location_Name()
        {
            string locationName = "Baden-Württemberg Karlsruhe, Germany";

            var actionResult = await controller.GetLocationDataViaIP(ip);

            var result = actionResult.Result as OkObjectResult;

            var returnData = result.Value as LocationDataViewModel;

            Assert.Equal(locationName, returnData.LocationName);
        }

        [Fact]
        public async Task GetLocationDataViaIP_Returns_Temperature()
        {
            var actionResult = await controller.GetLocationDataViaIP(ip);

            var result = actionResult.Result as OkObjectResult;

            var returnData = result.Value as LocationDataViewModel;

            Assert.NotNull(returnData.Temperature);
        }

        [Fact]
        public async Task GetLocationDataViaIP_Returns_Currency_Exchange_Rate()
        {
            string locationName = "Baden-Württemberg Karlsruhe, Germany";

            var actionResult = await controller.GetLocationDataViaIP(ip);

            var result = actionResult.Result as OkObjectResult;

            var returnData = result.Value as LocationDataViewModel;

            Assert.NotNull(returnData.GBPExchangeRate);
        }
    }
}