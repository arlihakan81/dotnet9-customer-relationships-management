using CRM.Application.Dtos.Stage;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Stage.Queries.GetPipelineStages
{
    public class GetStagesQuery : IRequest<BaseResponse<PagedList<StageDto>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public Guid? PipelineId { get; set; }
        public string? Filter { get; set; }


    }
}
