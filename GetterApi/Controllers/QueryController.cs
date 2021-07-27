using GetterApi.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueryController : ControllerBase
    {
        [HttpGet]
        [Route("{domain}")]
        public async Task<IActionResult> Get(string domain, [FromQuery] string [] services)
        {
            if (!Enum.IsDefined(typeof(Domains), domain.ToUpperInvariant()))
            {
                return BadRequest();
            }

            var rng = new Random();
            return Ok(Enumerable.Range(1, 5).Select(index => rng.Next(1, 10)).ToArray());
        }
    }
}
