using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.ContactStage.Commands.Update
{
    public sealed class UpdateContactStageCommandHandler(IContactStageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateContactStageCommand, BaseResponse<Guid>>
    {
        private readonly IContactStageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(UpdateContactStageCommand request, CancellationToken cancellationToken)
        {
            var stage = await _repository.GetByIdAsync(request.Id);

            if (stage == null)
            {
                return BaseResponse<Guid>.FailureResult("No contact stage found");
            }

            stage.Name = request.Name;
            stage.Status = request.Status;

            _repository.UpdateAsync(stage);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(stage.Id, "Contact stage has been updated successfully");
        }
    }
}
