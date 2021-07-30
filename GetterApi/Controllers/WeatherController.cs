namespace GetterApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GetterApiServices;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string[] services)
        {
            var response = await weatherService.GetEndPoints(services);

            return Ok(response);
        }
    }
}
