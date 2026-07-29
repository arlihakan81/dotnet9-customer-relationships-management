using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using MediatR;

namespace CRM.Application.Features.Company.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler(ICompanyRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id);
            if (company != null)
            {
                await _repository.DeleteAsync(company.Id);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
