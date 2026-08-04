using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using MediatR;

namespace CRM.Application.Features.Lead.Commands.Convert
{
    public sealed class ConvertLeadToCompanyCommandHandler(ILeadRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<ConvertLeadToCompanyCommand>
    {
        private readonly ILeadRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(ConvertLeadToCompanyCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByIdAsync(request.Id);
            if(lead is not null)
            {
                await _repository.ConvertLeadToCompanyAsync(request.Id);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
