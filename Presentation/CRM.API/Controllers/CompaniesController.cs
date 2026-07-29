using CRM.Application.Features.Company.Commands.CreateCompany;
using CRM.Application.Features.Company.Commands.DeleteCompany;
using CRM.Application.Features.Company.Commands.UpdateCompany;
using CRM.Application.Features.Company.Queries.GetCompanies;
using CRM.Application.Features.Company.Queries.GetCompany;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            if (ModelState.IsValid)
            {
                await _sender.Send(command);
                return Created();
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetCompaniesQuery query)
        {
            return Ok(await _sender.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCompanyByIdQuery { Id = id };
            return Ok(await _sender.Send(query));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompanyCommand command)
        {
            id = command.Id;
            await _sender.Send(command);
            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCompanyCommand { Id = id };
            await _sender.Send(command);
            return Ok($"{id}");
        }





    }
}
