using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Contact.Commands.Delete
{
    public sealed class DeleteContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteContactCommand, BaseResponse<Guid>>
    {
        private readonly IContactRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id);
            if (contact is null)
            {
                return BaseResponse<Guid>.FailureResult($"Contact with Id {request.Id} not found.");
            }
            await _repository.DeleteAsync(contact.Id);
            await _unitOfWork.SaveChangesAsync();
            return BaseResponse<Guid>.SuccessResult(contact.Id, "Contact deleted successfully.");
        }
    }
}
