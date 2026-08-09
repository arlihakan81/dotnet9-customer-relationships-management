using CRM.Application.Dtos.Pipeline;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Pipeline.Queries.GetPipeline
{
    public class GetPipelineByIdQuery : IRequest<BaseResponse<PipelineDto>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
