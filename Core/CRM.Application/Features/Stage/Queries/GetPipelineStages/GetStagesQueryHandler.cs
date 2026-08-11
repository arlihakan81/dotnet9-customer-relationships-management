using AutoMapper;
using CRM.Application.Dtos.Stage;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Stage.Queries.GetPipelineStages
{
    public sealed class GetStagesQueryHandler(IStageRepository repository, IMapper mapper) : IRequestHandler<GetStagesQuery, BaseResponse<PagedList<StageDto>>>
    {
        private readonly IStageRepository _repository = repository;
        private readonly IMapper _mapper = mapper;   

        public async Task<BaseResponse<PagedList<StageDto>>> Handle(GetStagesQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAllAsync(request.Page, request.PageSize);

            if (request.Filter is not null)
                query = query!.Where(_ => _.Name.Contains(request.Filter));

            if (request.PipelineId is not null)
                query = query!.Where(_ => _.PipelineId == request.PipelineId);

            var data = _mapper.Map<IEnumerable<StageDto>>(query);
            var items = new PagedList<StageDto>(data, request.Page, request.PageSize);

            return BaseResponse<PagedList<StageDto>>.SuccessResult(items, 200, "Retrieved all pipeline stages succeed");
        }
    }
}
