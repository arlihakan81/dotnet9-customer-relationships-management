using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Lead.Commands.Delete
{
    public sealed class DeleteLeadCommandHandler(ILeadRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteLeadCommand, BaseResponse<Guid>>
    {
        private readonly ILeadRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByIdAsync(request.Id);
            if (lead is null)
                return BaseResponse<Guid>.FailureResult("No lead found", "No lead found");
            await _repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return BaseResponse<Guid>.SuccessResult(lead.Id, "Lead deleted successfully");
        }
    }
}
