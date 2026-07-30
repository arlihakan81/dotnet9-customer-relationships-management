using CRM.Application.Dtos.Company;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Company.Queries.GetCompanies
{
    public class GetCompaniesQuery : IRequest<BaseResponse<PagedList<CompanyDto>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string? Filter { get; set; }
        public Guid? OwnerId { get; set; }
        public bool Status { get; set; } = true;

    }
}
