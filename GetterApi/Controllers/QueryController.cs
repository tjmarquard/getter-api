using GetterApi.Extensions;
using GetterApi.Models;
using GetterApiServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GetterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueryController : ControllerBase
    {
        private IQueryService _queryService;

        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet]
        [Route("{domain}")]
        public async Task<IActionResult> Get(string domain, [FromQuery] string[] services)
        {
            if (!typeof(Domains).HasField(domain))
            {
                return BadRequest();
            }

            return Ok(_queryService.GetWeatherApiEndPoints(services));
        }
    }
}
