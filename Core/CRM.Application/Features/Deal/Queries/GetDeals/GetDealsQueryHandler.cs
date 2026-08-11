using AutoMapper;
using CRM.Application.Dtos.Deal;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Deal.Queries.GetDeals
{
    public sealed class GetDealsQueryHandler(IDealRepository repository, IMapper mapper) : IRequestHandler<GetDealsQuery, BaseResponse<PagedList<DealDto>>>
    {
        private readonly IDealRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<PagedList<DealDto>>> Handle(GetDealsQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAllAsync(request.Page, request.PageSize);

            if(request.Filter != null)
                query = query!.Where(_ => _.Name.Contains(request.Filter));
            if (request.OwnerId != null)
                query = query!.Where(_ => _.OwnerId == request.OwnerId);
            if (request.PipelineId != null)
                query = query!.Where(_ => _.PipelineId == request.PipelineId);
            if (request.StageId != null)
                query = query!.Where(_ => _.StageId == request.StageId);

            var data = _mapper.Map<IEnumerable<DealDto>>(query);
            var items = new PagedList<DealDto>(data, request.Page, request.PageSize);

            return BaseResponse<PagedList<DealDto>>.SuccessResult(items, 200, "Retrieved all deals succeed");
        }
    }
}
