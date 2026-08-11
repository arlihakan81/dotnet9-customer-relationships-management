using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Stage.Commands.Update
{
    public class UpdateStageCommandHandler(IStageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateStageCommand, BaseResponse<Guid>>
    {
        private readonly IStageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(UpdateStageCommand request, CancellationToken cancellationToken)
        {
            var stage = await _repository.GetByIdAsync(request.Id);

            if (stage == null) 
            {
                return BaseResponse<Guid>.FailureResult("No pipeline stage found", 404, $"No pipeline stage by stage Id {request.Id}"); 
            }

            stage.Name = request.Name;
            stage.PipelineId = request.PipelineId;

            _repository.UpdateAsync(stage);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(stage.Id, 204, "The pipeline stage has been updated succeed");

        }
    }
}
