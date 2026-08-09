using CRM.Application.Dtos.Pipeline;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Pipeline.Queries.GetPipelines
{
    public class GetPipelinesQuery : IRequest<BaseResponse<PagedList<PipelineDto>>>
    {
        [Required]
        public int Page { get; set; } = 1;
        [Required]
        public int PageSize { get; set; } = 100;

        public string? Filter { get; set; }



    }
}
