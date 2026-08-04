using AutoMapper;
using CRM.Application.Dtos.Lead;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Lead.Queries.GetLeads
{
    public sealed class GetLeadsQueryHandler(ILeadRepository repository, IMapper mapper) : IRequestHandler<GetLeadsQuery, BaseResponse<IEnumerable<LeadDto>>>
    {
        private readonly ILeadRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<IEnumerable<LeadDto>>> Handle(GetLeadsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _repository.GetAllAsync(request.Page, request.PageSize);
                if (request.Filter is not null)
                    query = query!.Where(_ => _.Name.Contains(request.Filter));
                if(request.OwnerId is not null)
                    query = query!.Where(_ => _.OwnerId == request.OwnerId);
                var leadDtos = _mapper.Map<IEnumerable<LeadDto>>(query);
                return BaseResponse<IEnumerable<LeadDto>>.SuccessResult(leadDtos, "Leads retrieved successfully.");
            }
            catch (Exception ex)
            {
                return BaseResponse<IEnumerable<LeadDto>>.FailureResult(new List<string> { ex.Message }, "An error occurred while retrieving leads.");
            }
        }
    }
}
