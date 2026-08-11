using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Deal.Commands.Delete
{
    public class DeleteDealCommandHandler(IDealRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteDealCommand, BaseResponse<Guid>>
    {
        private readonly IDealRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(DeleteDealCommand request, CancellationToken cancellationToken)
        {
            var deal = await _repository.GetByIdAsync(request.Id);

            if (deal is null)
                return BaseResponse<Guid>.FailureResult("Operation failed", 404, $"No deal found by deal Id {request.Id}");

            await _repository.DeleteAsync(deal.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(deal.Id, 204, "The deal has been deleted successfully");
        }
    }
}
