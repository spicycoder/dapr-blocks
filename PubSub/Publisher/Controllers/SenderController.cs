using Dapr.Client;
using Library;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private const string PubSubName = "pubsub";
        private const string TopicName = "HeroCreated";
        private readonly DaprClient _daprClient;
        private readonly ILogger<SenderController> _logger;

        public SenderController(
            DaprClient daprClient,
            ILogger<SenderController> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        [HttpPost("publish")]
        public async Task<IActionResult> Publish([FromBody] Hero hero)
        {
            _logger.LogInformation("Publishing hero, Name: {name}, Identity: {id}", hero.Name, hero.Identity);
            await _daprClient.PublishEventAsync(
                PubSubName,
                TopicName,
                hero);

            return Ok();
        }
    }
}
