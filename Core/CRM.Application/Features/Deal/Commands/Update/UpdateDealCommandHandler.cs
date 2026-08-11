using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;
using System.Reflection;

namespace CRM.Application.Features.Deal.Commands.Update
{
    public class UpdateDealCommandHandler(IDealRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateDealCommand, BaseResponse<Guid>>
    {
        private readonly IDealRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(UpdateDealCommand request, CancellationToken cancellationToken)
        {
            var deal = await _repository.GetByIdAsync(request.Id);

            if (deal is null)
                return BaseResponse<Guid>.FailureResult("Operation failed", 400, $"No deal found by deal Id {request.Id}");

            if (deal.Stage.PipelineId != request.PipelineId)
                return BaseResponse<Guid>.FailureResult("Operation failed", 400, $"{request.PipelineId} does not match {deal.Stage.PipelineId}");

            deal.Name = request.Name;
            deal.PipelineId = request.PipelineId;
            deal.StageId = request.StageId;
            deal.Status = request.Status;
            deal.Value = request.Value;
            deal.SourceId = request.SourceId;
            deal.CurrencyId = request.CurrencyId;
            deal.Description = request.Description;
            deal.ContactId = request.ContactId;
            deal.CompanyId = request.CompanyId;
            deal.DueDate = request.DueDate;
            deal.ExpectedClosingDate = request.ExpectedClosingDate;
            deal.OwnerId = request.OwnerId;

            _repository.UpdateAsync(deal);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(deal.Id, 204, "The Deal has been updated successfully");
        }
    }
}
