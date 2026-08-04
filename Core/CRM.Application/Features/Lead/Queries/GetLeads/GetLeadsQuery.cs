using CRM.Application.Dtos.Lead;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Lead.Queries.GetLeads
{
    public sealed class GetLeadsQuery : IRequest<BaseResponse<IEnumerable<LeadDto>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string? Filter { get; set; }

        public Guid? OwnerId { get; set; }


    }
}
