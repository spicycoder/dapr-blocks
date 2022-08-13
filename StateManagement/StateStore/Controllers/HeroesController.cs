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

        public HeroesController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] Hero hero)
        {
            await _daprClient.SaveStateAsync<string>(
                StateStoreName,
                hero.Name,
                hero.Identity);

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
                return NotFound();
            }

            return Ok(identity);
        }
    }
}
