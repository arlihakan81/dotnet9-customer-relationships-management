using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Source.Commands.Create
{
    public sealed class CreateSourceCommandHandler(ISourceRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateSourceCommand, BaseResponse<Guid>>
    {
        private readonly ISourceRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<Guid>> Handle(CreateSourceCommand request, CancellationToken cancellationToken)
        {
            var existingSource = await _repository.GetAsync(_ => _.Name == request.Name);
            if (existingSource != null)
            {
                return BaseResponse<Guid>.FailureResult("Operation failed", 400, $"{request.Name} already exists");
            }

            var source = new Domain.Entities.Source
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status
            };

            await _repository.AddAsync(source);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return BaseResponse<Guid>.SuccessResult(source.Id, 201, "The new source has been added successfully");
        }
    }
}
