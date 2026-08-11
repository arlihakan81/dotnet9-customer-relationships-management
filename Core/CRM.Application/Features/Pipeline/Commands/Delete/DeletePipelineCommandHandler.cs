using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Pipeline.Commands.Delete
{
    public class DeletePipelineCommandHandler(IPipelineRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeletePipelineCommand, BaseResponse<Guid>>
    {
        private readonly IPipelineRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(DeletePipelineCommand request, CancellationToken cancellationToken)
        {
            var pipeline = await _repository.GetByIdAsync(request.Id);
            if (pipeline == null)
            {
                return BaseResponse<Guid>.FailureResult("No pipeline found", 404, $"No pipeline found by pipeline Id {request.Id}");
            }

            await _repository.DeleteAsync(pipeline.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(pipeline.Id, 204, "The pipeline has been deleted successfully");
        }
    }
}
