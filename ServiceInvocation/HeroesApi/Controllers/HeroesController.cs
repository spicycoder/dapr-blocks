using Dapr.Client;
using Library;
using Microsoft.AspNetCore.Mvc;

namespace HeroesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        public const string ContactsApiName = "contacts-api";
        private readonly DaprClient _daprClient;
        private readonly ILogger<HeroesController> _logger;

        public HeroesController(
            DaprClient daprClient,
            ILogger<HeroesController> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        [HttpGet("info")]
        public async Task<ActionResult<Contact>> GetHeroInfo(string name)
        {
            var contact = await _daprClient.InvokeMethodAsync<Contact>(
                HttpMethod.Get,
                ContactsApiName,
                $"/api/Contacts/read?name={name}");

            if (contact == null)
            {
                _logger.LogError("Unable to find contact for {name}", name);
                return NotFound();
            }

            _logger.LogInformation("Contact found, Email: {email}, Phone: {phone}", contact.Email, contact.Phone);
            return Ok(contact);
        }
    }
}
