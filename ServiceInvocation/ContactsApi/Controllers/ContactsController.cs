using Bogus;
using Library;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("read")]
        public async Task<ActionResult<Contact>> Read(string name)
        {
            var contact = new Faker<Contact>()
                .RuleFor(x => x.Email, x => x.Internet.Email())
                .RuleFor(x => x.Phone, x => x.Phone.PhoneNumber())
                .Generate();

            _logger.LogInformation("Contact information of {hero} is Email: {email}, Phone: {phone}", name, contact.Email, contact.Phone);

            return Ok(contact);
        }
    }
}
