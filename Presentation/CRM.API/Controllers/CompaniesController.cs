using CRM.Application.Features.Company.Commands.CreateCompany;
using CRM.Application.Features.Company.Commands.DeleteCompany;
using CRM.Application.Features.Company.Commands.UpdateCompany;
using CRM.Application.Features.Company.Queries.GetCompanies;
using CRM.Application.Features.Company.Queries.GetCompany;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            var result = await _sender.Send(command);
            if(!result.Success)
            {
                return StatusCode(result.StatusCode, new { error = result.Errors });
            }
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetCompaniesQuery query)
        {
            var result = await _sender.Send(query);
            if (!result.Success)
                return StatusCode(result.StatusCode, new { error = result.Errors });

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCompanyByIdQuery { Id = id };
            var result = await _sender.Send(query);
            if (!result.Success)
                return StatusCode(result.StatusCode, new { error = result.Errors });
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompanyCommand command)
        {
            id = command.Id;
            return Ok(await _sender.Send(command));
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
