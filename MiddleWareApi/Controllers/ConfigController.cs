using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MiddleWareApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("")]
        public ActionResult GetConfig()
        {
            var config = new
            {
                AllowedHosts = _configuration["AllowedHosts"],


                //DefaultConnection = _configuration["ConnectionStrings:Default"]
                DefaultLogLevel = _configuration["Logging:LogLevel:Default"],
                DefaultLogLevel2 = _configuration["Logging:LogLevel:Microsoft.AspNetCore"]
            };
            return Ok(config);
        }
    }
}
