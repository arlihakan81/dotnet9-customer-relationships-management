using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Stage.Commands.Create
{
    public sealed class CreateStageCommandHandler(IStageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateStageCommand, BaseResponse<Guid>>
    {
        private readonly IStageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(CreateStageCommand request, CancellationToken cancellationToken)
        {
            var stage = await _repository.GetAsync(_ => _.Name == request.Name && _.PipelineId == request.PipelineId);

            if (stage != null)
            {
                return BaseResponse<Guid>.FailureResult("The stage already exists", $"{request.Name} stage already exists in this pipeline Id {request.PipelineId} ");
            }

            var newStage = new Domain.Entities.Stage
            {
                Name = request.Name,
                PipelineId = request.PipelineId
            };

            await _repository.AddAsync(newStage);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(newStage.Id, "The new stage has been added successfully");

        }
    }
}
