using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using MediatR;

namespace CRM.Application.Features.ContactStage.Commands.Create
{
    public sealed class CreateContactStageCommandHandler(IContactStageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateContactStageCommand>
    {
        private readonly IContactStageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateContactStageCommand request, CancellationToken cancellationToken)
        {
            var contactStage = new Domain.Entities.ContactStage
            {
                Name = request.Name,
                Status = request.Status
            };
            await _repository.AddAsync(contactStage);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
