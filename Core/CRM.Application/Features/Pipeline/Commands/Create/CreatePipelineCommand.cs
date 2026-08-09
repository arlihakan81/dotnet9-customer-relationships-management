using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Pipeline.Commands.Create
{
    public class CreatePipelineCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
