using CRM.Application.Features.Stage.Commands.Create;
using CRM.Application.Features.Stage.Commands.Delete;
using CRM.Application.Features.Stage.Commands.Update;
using CRM.Application.Features.Stage.Queries.GetPipelineStage;
using CRM.Application.Features.Stage.Queries.GetPipelineStages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class StagesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetStagesQuery query)
            => Ok(await _sender.Send(query));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetStageByIdQuery { Id = id };
            return Ok(await _sender.Send(query));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStageCommand command)
          => Ok(await _sender.Send(command));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateStageCommand command)
        {
            id = command.Id;
            return Ok(await _sender.Send(command));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteStageCommand { Id = id };
            return Ok(await _sender.Send(command));
        }








    }
}
