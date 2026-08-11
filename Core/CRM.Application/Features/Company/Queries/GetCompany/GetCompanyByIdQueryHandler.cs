using AutoMapper;
using CRM.Application.Dtos.Company;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Company.Queries.GetCompany
{
    public class GetCompanyByIdQueryHandler(ICompanyRepository repository, IMapper mapper) : IRequestHandler<GetCompanyByIdQuery, BaseResponse<CompanyDto>>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<CompanyDto>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id);
            if (company == null)
            {
                return BaseResponse<CompanyDto>.FailureResult("No company found", 404, $"No company found by company Id {request.Id}");
            }

            var data = _mapper.Map<CompanyDto>(company);
            return BaseResponse<CompanyDto>.SuccessResult(data, 200);
        }
    }
}
