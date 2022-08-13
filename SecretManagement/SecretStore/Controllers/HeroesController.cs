using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace SecretStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private const string SecretStoreName = "secretstore";
        private readonly DaprClient _daprClient;
        private readonly ILogger<HeroesController> _logger;

        public HeroesController(
            DaprClient daprClient,
            ILogger<HeroesController> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        [HttpGet("read")]
        public async Task<ActionResult<string>> Read([FromQuery] string name)
        {
            var secrets = await _daprClient.GetBulkSecretAsync(SecretStoreName);

            if (
                !secrets.ContainsKey(name) ||
                !secrets[name].ContainsKey(name))
            {
                _logger.LogError("Secret not found for Key: {key}", name);
                return NotFound();
            }

            var identity = secrets[name][name];

            _logger.LogInformation("{identity} is {hero}", identity, name);
            return Ok(identity);
        }
    }
}
