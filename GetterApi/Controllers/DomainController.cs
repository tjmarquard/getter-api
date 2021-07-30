namespace GetterApi.Controllers
{
    using GetterApiServices;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly IDomainService domainService;

        public DomainController(IDomainService domainService)
        {
            this.domainService = domainService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(domainService.GetDomains());
        }
    }
}
