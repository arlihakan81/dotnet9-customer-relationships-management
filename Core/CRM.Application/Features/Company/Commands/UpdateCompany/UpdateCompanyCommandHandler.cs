using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using MediatR;

namespace CRM.Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler(ICompanyRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id);
            if(company != null)
            {
                company.Name = request.Name;
                company.Description = request.Description;
                company.Phone = request.Phone;
                company.City = request.City;
                company.Country = request.Country;
                company.Source = request.Source;
                company.State = request.State;
                company.StreetAddress = request.StreetAddress;
                company.Title = request.Title;
                company.Website = request.Website;
                company.WhatsappUrl = request.WhatsappUrl;
                company.InstagramUrl = request.InstagramUrl;
                company.X_Url = request.X_Url;
                company.AvatarUrl = request.AvatarUrl;
                company.Currency = request.Currency;
                company.FacebookUrl = request.FacebookUrl;
                company.AlternatePhone = request.AlternatePhone;
                company.Email = request.Email;
                company.Fax = request.Fax;
                company.LinkedinUrl = request.LinkedinUrl;
                company.Status = request.Status;
                company.OwnerId = request.OwnerId;
            }
            _repository.UpdateAsync(company!);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
