using CRM.Application.Features.Pipeline.Commands.Create;
using CRM.Application.Features.Pipeline.Commands.Delete;
using CRM.Application.Features.Pipeline.Commands.Update;
using CRM.Application.Features.Pipeline.Queries.GetPipeline;
using CRM.Application.Features.Pipeline.Queries.GetPipelines;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PipelinesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetPipelinesQuery query)
            => Ok(await _sender.Send(query));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetPipelineByIdQuery { Id = id };
            return Ok(await _sender.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePipelineCommand command)
        {
            return Ok(await _sender.Send(command));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePipelineCommand command)
        {
            id = command.Id;
            return Ok(await _sender.Send(command));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePipelineCommand { Id = id };
            return Ok(await _sender.Send(command));
        }





    }
}
