using CRM.Application.Dtos.ContactStage;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.ContactStage.Queries.GetContactStages
{
    public class GetContactStagesQuery : IRequest<BaseResponse<PagedList<ContactStageDto>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string? Filter { get; set; }


    }
}
