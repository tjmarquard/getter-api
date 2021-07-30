namespace GetterApi.Controllers
{
    using System.Threading.Tasks;
    using GetterApiServices;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string[] services)
        {
            var response = await weatherService.GetEndpoints(services);

            return Ok(response);
        }
    }
}
