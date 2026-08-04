using CRM.Application.Features.Lead.Commands.Convert;
using CRM.Application.Features.Lead.Commands.Create;
using CRM.Application.Features.Lead.Commands.Delete;
using CRM.Application.Features.Lead.Commands.Update;
using CRM.Application.Features.Lead.Queries.GetLead;
using CRM.Application.Features.Lead.Queries.GetLeads;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class LeadsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetLeadsQuery query)
        {
            return Ok(await _sender.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeadCommand command)
        {
            await _sender.Send(command);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateLeadCommand command)
        {
            id = command.Id;
            await _sender.Send(command);
            return NoContent();
        }

        [HttpPost("{id:guid}/convert")]
        public async Task<IActionResult> Convert(Guid id)
        {
            var command = new ConvertLeadToCompanyCommand { Id = id };
            await _sender.Send(command);
            return Ok();
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetLeadByIdQuery { Id = id };
            return Ok(await _sender.Send(query));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteLeadCommand { Id = id };
            return Ok(await _sender.Send(command));
        }


    }
}
