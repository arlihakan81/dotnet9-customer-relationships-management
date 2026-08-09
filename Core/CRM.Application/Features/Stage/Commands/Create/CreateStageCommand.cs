using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Stage.Commands.Create
{
    public class CreateStageCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Guid PipelineId { get; set; }
    }
}
