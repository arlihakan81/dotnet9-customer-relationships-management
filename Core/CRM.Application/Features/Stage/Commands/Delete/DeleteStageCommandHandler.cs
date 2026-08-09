using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Stage.Commands.Delete
{
    public sealed class DeleteStageCommandHandler(IStageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteStageCommand, BaseResponse<Guid>>
    {
        private readonly IStageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(DeleteStageCommand request, CancellationToken cancellationToken)
        {
            var stage = await _repository.GetByIdAsync(request.Id);
            if (stage == null)
            {
                return BaseResponse<Guid>.FailureResult("No pipeline stage found", $"No pipeline stage found by stage Id {request.Id}");
            }

            await _repository.DeleteAsync(stage.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(stage.Id, "The pipeline stage has been deleted");
        }
    }
}
