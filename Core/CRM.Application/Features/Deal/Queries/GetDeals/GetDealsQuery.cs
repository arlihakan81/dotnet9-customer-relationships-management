using CRM.Application.Dtos.Deal;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Deal.Queries.GetDeals
{
    public class GetDealsQuery : IRequest<BaseResponse<PagedList<DealDto>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;

        public string? Filter { get; set; }

        public Guid? OwnerId { get; set; }
        public Guid? PipelineId { get; set; }
        public Guid? StageId { get; set; }




    }
}
