using AutoMapper;
using CRM.Application.Dtos.Lead;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Lead.Queries.GetLead
{
    public sealed class GetLeadByIdQueryHandler(ILeadRepository repository, IMapper mapper) : IRequestHandler<GetLeadByIdQuery, BaseResponse<LeadDto>>
    {
        private readonly ILeadRepository _repository = repository;
        private readonly IMapper _mapper = mapper;


        public async Task<BaseResponse<LeadDto>> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByIdAsync(request.Id);
            if (lead is null)
                return BaseResponse<LeadDto>.FailureResult("No lead found", $"No lead found with by Id query = {request.Id}");

            var data = _mapper.Map<LeadDto>(lead);
            return BaseResponse<LeadDto>.SuccessResult(data, "Retrieved lead data");
        }
    }
}
