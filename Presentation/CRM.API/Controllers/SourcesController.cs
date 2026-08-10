using CRM.Application.Features.Source.Commands.Create;
using CRM.Application.Features.Source.Queries.GetSources;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class SourcesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetSourcesQuery query)
            => Ok(await _sender.Send(query));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSourceCommand command)
            => Ok(await _sender.Send(command));

    }
}
