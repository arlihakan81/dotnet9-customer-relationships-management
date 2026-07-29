using CRM.Application.Dtos.Company;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Company.Queries.GetCompany
{
    public class GetCompanyByIdQuery : IRequest<BaseResponse<CompanyDto>>
    {
        public Guid Id { get; set; }
    }
}
