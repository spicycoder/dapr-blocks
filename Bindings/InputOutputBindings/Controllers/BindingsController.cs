using Bogus;
using Dapr.Client;
using Library;
using Microsoft.AspNetCore.Mvc;

namespace InputOutputBindings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingsController : ControllerBase
    {
        private const string BindingName = "sendemail";
        private const string Operation = "create";
        private readonly DaprClient _daprClient;
        private readonly ILogger<BindingsController> _logger;

        public BindingsController(
            DaprClient daprClient,
            ILogger<BindingsController> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> CreateContact()
        {
            var contact = new Faker<Contact>()
                .RuleFor(x => x.Email, x => x.Internet.Email())
                .RuleFor(x => x.Phone, x => x.Phone.PhoneNumber())
                .Generate();

            _logger.LogInformation("New contact created, Email: {email}, Phone: {phone}", contact.Email, contact.Phone);

            // prepare email
            var metadata = new Dictionary<string, string>
            {
                ["emailFrom"] = "hello@world.com",
                ["emailTo"] = "world@hello.com",
                ["subject"] = "New contact created!"
            };

            var body = $"New contact created, Email: {contact.Email}, Phone: {contact.Phone}";

            // send email
            await _daprClient.InvokeBindingAsync(
                BindingName,
                Operation,
                body,
                metadata);

            return Ok();
        }
    }
}
