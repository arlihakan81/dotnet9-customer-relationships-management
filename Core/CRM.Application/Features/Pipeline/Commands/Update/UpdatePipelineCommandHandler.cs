using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Pipeline.Commands.Update
{
    public class UpdatePipelineCommandHandler(IPipelineRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdatePipelineCommand, BaseResponse<Guid>>
    {
        private readonly IPipelineRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(UpdatePipelineCommand request, CancellationToken cancellationToken)
        {
            var pipeline = await _repository.GetByIdAsync(request.Id);
            if (pipeline == null)
            {
                return BaseResponse<Guid>.FailureResult("No pipeline found", 404, $"No pipeline found by pipeline Id: {request.Id}");
            }
            var isUnique = await _repository.GetAsync(_ => _.Name == request.Name && _.Id != pipeline.Id);

            if (isUnique != null)
                return BaseResponse<Guid>.FailureResult("Operation failed", 404, $"{request.Name} alreay exists");

            pipeline.Name = request.Name;

            _repository.UpdateAsync(pipeline);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(pipeline.Id, 204, "The pipeline has been updated successfully");

        }
    }
}
