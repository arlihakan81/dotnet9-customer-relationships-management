using AutoMapper;
using CRM.Application.Dtos.Company;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Company.Queries.GetCompanies
{
    public class GetCompaniesQueryHandler(ICompanyRepository repository, IMapper mapper) : IRequestHandler<GetCompaniesQuery, BaseResponse<PagedList<CompanyDto>>>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IMapper _mapper = mapper;


        public async Task<BaseResponse<PagedList<CompanyDto>>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAllAsync(request.Page, request.PageSize);
            if(request.Filter != null)
            {
                query = query?.Where(_ => _.Name.Contains(request.Filter));
            }
            else if(request.OwnerId != null)
            {
                query = query?.Where(_ => _.OwnerId == request.OwnerId && _.Status == request.Status);
            }
            if (query != null)
            {
                var data = _mapper.Map<List<CompanyDto>>(query);
                var items = new PagedList<CompanyDto>(data, request.Page, request.PageSize);
                return BaseResponse<PagedList<CompanyDto>>.SuccessResult(items, 200);
            }
            return new BaseResponse<PagedList<CompanyDto>>();
        }
    }
}
