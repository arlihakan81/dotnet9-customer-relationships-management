using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using MediatR;

namespace CRM.Application.Features.Company.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler(ICompanyRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Domain.Entities.Company
            {
                AvatarUrl = request.AvatarUrl,
                Name = request.Name,
                Title = request.Title,
                Email = request.Email,
                Phone = request.Phone,
                AlternatePhone = request.AlternatePhone,
                City = request.City,
                Country = request.Country,
                Currency = request.Currency,
                Source = request.Source,
                Description = request.Description,
                Fax = request.Fax,
                Website = request.Website,
                State = request.State,
                StreetAddress = request.StreetAddress,
                FacebookUrl = request.FacebookUrl,
                InstagramUrl = request.InstagramUrl,
                X_Url = request.X_Url,
                LinkedinUrl = request.LinkedinUrl,
                WhatsappUrl = request.WhatsappUrl,
                OwnerId = request.OwnerId,
                Status = request.Status
            };
            await _repository.AddAsync(company);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
