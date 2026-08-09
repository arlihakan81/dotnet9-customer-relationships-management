using AutoMapper;
using CRM.Application.Dtos.Pipeline;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Pipeline.Queries.GetPipelines
{
    public sealed class GetPipelinesQueryHandler(IPipelineRepository repository, IMapper mapper) : IRequestHandler<GetPipelinesQuery, BaseResponse<PagedList<PipelineDto>>>
    {
        private readonly IPipelineRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<PagedList<PipelineDto>>> Handle(GetPipelinesQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAllAsync(request.Page, request.PageSize);

            if (request.Filter is not null)
                query = query!.Where(_ => _.Name.Contains(request.Filter));

            //if(query!.Count() == 0)
            //    return BaseResponse<PagedList<PipelineDto>>.FailureResult("No found any pipeline", "Request succeed but there is no data");

            var data = _mapper.Map<IEnumerable<PipelineDto>>(query);
            var items = new PagedList<PipelineDto>(data, request.Page, request.PageSize);

            return BaseResponse<PagedList<PipelineDto>>.SuccessResult(items, "Retrieved all pipelines successfully");
        }
    }
}
