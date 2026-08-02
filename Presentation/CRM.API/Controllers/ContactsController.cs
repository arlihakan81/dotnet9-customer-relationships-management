using CRM.Application.Features.Contact.Commands.Create;
using CRM.Application.Features.Contact.Queries.GetContacts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetContactsQuery query)
        {
            return Ok(await _sender.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand command)
        {
            await _sender.Send(command);
            return Created();
        }



    }
}
