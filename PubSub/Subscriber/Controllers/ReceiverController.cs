using Dapr;
using Library;
using Microsoft.AspNetCore.Mvc;

namespace Subscriber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiverController : ControllerBase
    {
        private const string PubSubName = "pubsub";
        private const string TopicName = "HeroCreated";
        private readonly ILogger<ReceiverController> _logger;

        public ReceiverController(ILogger<ReceiverController> logger)
        {
            _logger = logger;
        }

        [Topic(PubSubName, TopicName)]
        [HttpPost("subscribe")]
        public async Task<IActionResult> Receive([FromBody] Hero hero)
        {
            _logger.LogInformation("Hero created, Name: {name}, Identity: {id}", hero.Name, hero.Identity);
            return Ok();
        }
    }
}
