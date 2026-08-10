using CRM.Application.Features.Contact.Commands.Create;
using CRM.Application.Features.Contact.Commands.Delete;
using CRM.Application.Features.Contact.Commands.Update;
using CRM.Application.Features.Contact.Queries.GetContact;
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
            => Ok(await _sender.Send(query));
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetContactByIdQuery { Id = id };
            return Ok(await _sender.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactCommand command)
            => Ok(await _sender.Send(command));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateContactCommand command)
        {
            id = command.Id;
            return Ok(await _sender.Send(command));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteContactCommand { Id = id };
            await _sender.Send(command);
            return NoContent();
        }






    }
}
