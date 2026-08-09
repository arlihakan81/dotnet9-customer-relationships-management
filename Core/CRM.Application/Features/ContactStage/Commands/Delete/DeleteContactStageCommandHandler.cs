using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.ContactStage.Commands.Delete
{
    public class DeleteContactStageCommandHandler(IContactStageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteContactStageCommand, BaseResponse<Guid>>
    {
        private readonly IContactStageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(DeleteContactStageCommand request, CancellationToken cancellationToken)
        {
            var stage = await _repository.GetByIdAsync(request.Id);
            if (stage == null)
            {
                return BaseResponse<Guid>.FailureResult("No contact stage found");
            }

            await _repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return BaseResponse<Guid>.SuccessResult(stage.Id, "Contact stage has been deleted successfully");
        }
    }
}
