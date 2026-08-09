using CRM.Application.Features.Deal.Commands.Create;
using CRM.Application.Features.Deal.Queries.GetDeals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class DealsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetDealsQuery query)
            => Ok(await _sender.Send(query));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDealCommand command)
            => Ok(await _sender.Send(command));












    }
}
