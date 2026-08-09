using CRM.Application.Features.ContactStage.Commands.Create;
using CRM.Application.Features.ContactStage.Commands.Delete;
using CRM.Application.Features.ContactStage.Commands.Update;
using CRM.Application.Features.ContactStage.Queries.GetContactStage;
using CRM.Application.Features.ContactStage.Queries.GetContactStages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactStagesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactStageCommand command)
        {
            await _sender.Send(command);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetContactStagesQuery query)
        {
            return Ok(await _sender.Send(query));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetContactStageByIdQuery { Id = id };
            return Ok(await _sender.Send(query));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateContactStageCommand command)
        {
            id = command.Id;
            return Ok(await _sender.Send(command));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteContactStageCommand { Id = id };
            return Ok(await _sender.Send(command));
        }








    }
}
