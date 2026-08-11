using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Pipeline.Commands.Create
{
    public sealed class CreatePipelineCommandHandler(IPipelineRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreatePipelineCommand, BaseResponse<Guid>>
    {
        private readonly IPipelineRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(CreatePipelineCommand request, CancellationToken cancellationToken)
        {
            var existPipeline = await _repository.GetAsync(_ => _.Name == request.Name);

            if (existPipeline is not null)
            {
                return BaseResponse<Guid>.FailureResult("Operation failed", 400, $"{request.Name} already exists");
            }

            var pipeline = new Domain.Entities.Pipeline
            {
                Name = request.Name
            };

            await _repository.AddAsync(pipeline);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return BaseResponse<Guid>.SuccessResult(pipeline.Id, 201, "New pipeline has been added successfully");
        }
    }
}
