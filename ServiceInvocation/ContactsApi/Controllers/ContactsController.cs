using Bogus;
using Library;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpGet("read")]
        public async Task<ActionResult<Contact>> Read(string name)
        {
            var contact = new Faker<Contact>()
                .RuleFor(x => x.Email, x => x.Internet.Email())
                .RuleFor(x => x.Phone, x => x.Phone.PhoneNumber())
                .Generate();

            return Ok(contact);
        }
    }
}
