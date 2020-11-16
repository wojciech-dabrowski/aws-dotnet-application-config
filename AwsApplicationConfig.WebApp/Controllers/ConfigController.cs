using AwsApplicationConfig.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AwsApplicationConfig.WebApp.Controllers
{
    [ApiController]
    [Route("api/config")]
    public class ConfigController : ControllerBase
    {
        private readonly ConfigModel _config;

        public ConfigController(IOptions<ConfigModel> settings)
        {
            _config = settings.Value;
        }

        [HttpGet]
        public ActionResult<ConfigModel> Get() => _config;
    }
}
