using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Deal.Commands.Create
{
    public sealed class CreateDealCommandHandler(IDealRepository repository, IStageRepository stageRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateDealCommand, BaseResponse<Guid>>
    {
        private readonly IDealRepository _repository = repository;
        private readonly IStageRepository _stageRepository = stageRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(CreateDealCommand request, CancellationToken cancellationToken)
        {
            var isUnique = await _repository.GetAsync(_ => _.Name == request.Name);
            if (isUnique != null)
                return BaseResponse<Guid>.FailureResult("The deal name already exists", 400, $"{request.Name} already exists");

            var stage = await _stageRepository.GetByIdAsync(request.StageId);

            if (stage is null)
                return BaseResponse<Guid>.FailureResult("Operation failed", 400, $"{request.StageId} does not found ");

            if (request.PipelineId != stage.PipelineId)
                return BaseResponse<Guid>.FailureResult("Operation failed", 400, $"{request.PipelineId} does not match {stage.PipelineId}");

            var deal = new Domain.Entities.Deal
            {
                Name = request.Name,
                Value = request.Value,
                PipelineId = request.PipelineId,
                StageId = request.StageId,
                Status = request.Status,
                CurrencyId = request.CurrencyId,
                ContactId = request.ContactId,
                CompanyId = request.CompanyId,
                SourceId = request.SourceId,
                Description = request.Description,
                DueDate = request.DueDate,
                ExpectedClosingDate = request.ExpectedClosingDate,
                OwnerId = request.OwnerId
            };

            await _repository.AddAsync(deal);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return BaseResponse<Guid>.SuccessResult(deal.Id, 201, "The new deal has been added succeed");
        }
    }
}
