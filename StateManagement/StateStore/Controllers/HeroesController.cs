using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace StateStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private const string StateStoreName = "statestore";
        private readonly DaprClient _daprClient;
        private readonly ILogger<HeroesController> _logger;

        public HeroesController(
            DaprClient daprClient,
            ILogger<HeroesController> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] Hero hero)
        {
            await _daprClient.SaveStateAsync<string>(
                StateStoreName,
                hero.Name,
                hero.Identity);

            _logger.LogInformation("Saving state Key: {key}, Value: {value}", hero.Name, hero.Identity);

            return Ok();
        }

        [HttpGet("read")]
        public async Task<ActionResult<string>> Read([FromQuery] string name)
        {
            var identity = await _daprClient.GetStateAsync<string>(
                StateStoreName,
                name);

            if (identity == null)
            {
                _logger.LogError("State not found for Key: {key}", name);
                return NotFound();
            }

            _logger.LogInformation("Reading State Key: {key}, Value: {value}", name, identity);
            return Ok(identity);
        }
    }
}
