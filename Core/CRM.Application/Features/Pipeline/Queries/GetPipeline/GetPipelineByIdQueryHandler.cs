using AutoMapper;
using CRM.Application.Dtos.Pipeline;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Pipeline.Queries.GetPipeline
{
    public sealed class GetPipelineByIdQueryHandler(IPipelineRepository repository, IMapper mapper) : IRequestHandler<GetPipelineByIdQuery, BaseResponse<PipelineDto>>
    {
        private readonly IPipelineRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<PipelineDto>> Handle(GetPipelineByIdQuery request, CancellationToken cancellationToken)
        {
            var pipeline = await _repository.GetByIdAsync(request.Id);
            if (pipeline == null)
                return BaseResponse<PipelineDto>.FailureResult("No pipeline found", $"No pipeline found by pipeline Id: {request.Id}");
            var data = _mapper.Map<PipelineDto>(pipeline);
            return BaseResponse<PipelineDto>.SuccessResult(data, "Retrieved requested data successfully");
        }
    }
}
