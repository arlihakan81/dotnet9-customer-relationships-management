using AutoMapper;
using CRM.Application.Dtos.Stage;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Stage.Queries.GetPipelineStage
{
    public class GetStageByIdQueryHandler(IStageRepository repository, IMapper mapper) : IRequestHandler<GetStageByIdQuery, BaseResponse<StageDto>>
    {
        private readonly IStageRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<StageDto>> Handle(GetStageByIdQuery request, CancellationToken cancellationToken)
        {
            var stage = await _repository.GetByIdAsync(request.Id);
            if (stage == null)
            {
                return BaseResponse<StageDto>.FailureResult("No pipeline stage found", 404, $"No pipeline stage found by stage Id {request.Id}");
            }

            var data = _mapper.Map<StageDto>(stage);
            return BaseResponse<StageDto>.SuccessResult(data, 200, "Retrieved requested data succeed");

        }
    }
}
