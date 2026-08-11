using CRM.Application.Dtos.Company;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using CRM.Domain.Entities;
using MediatR;

namespace CRM.Application.Features.Lead.Commands.Convert
{
    public sealed class ConvertLeadCommandHandler(ILeadRepository repository,
        ICompanyRepository companyRepository, IContactRepository contactRepository, IUnitOfWork unitOfWork) : IRequestHandler<ConvertLeadCommand, BaseResponse<Guid>>
    {
        private readonly ILeadRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IContactRepository _contactRepository = contactRepository;

        public async Task<BaseResponse<Guid>> Handle(ConvertLeadCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var lead = await _repository.GetByIdAsync(request.Id);
                if (lead is null)
                    return BaseResponse<Guid>.FailureResult("No lead found", 404, $"No lead found by with Id:{request.Id}");
                if (lead.Status)
                    return BaseResponse<Guid>.FailureResult("The lead has been converted already", 400);
                // Convert process ...

                Domain.Entities.Company company = new();

                if (request.ExistingCompanyId.HasValue)
                {
                    company = await _companyRepository.GetByIdAsync(request.ExistingCompanyId.Value);
                    if (company is null)
                        return BaseResponse<Guid>.FailureResult("No company found", 404, $"No company found by with Id: {request.ExistingCompanyId.Value}");                    
                }
                else
                {
                    company = new Domain.Entities.Company
                    {
                        Name = lead.CompanyName,
                        Email = new Domain.ValueObjects.EmailAddress(lead.Email.Value),
                        SourceId = lead.SourceId,
                        CityId = lead.CityId,
                        CountryId = lead.CountryId,
                        Phone = new Domain.ValueObjects.PhoneNumber(lead.Phone.Value),
                        Title = lead.CompanyName,
                        CurrencyId = lead.CurrencyId,
                        IndustryId = lead.IndustryId,
                        OwnerId = lead.OwnerId
                    };
                    await _companyRepository.AddAsync(company);

                    var contact = new Domain.Entities.Contact
                    {
                        FirstName = lead.FirstName,
                        LastName = lead.LastName,
                        Email = new Domain.ValueObjects.EmailAddress(lead.Email.Value),
                        Mobile = new Domain.ValueObjects.PhoneNumber(lead.Phone.Value),
                        Title = lead.JobTitle,
                        CityId = lead.CityId,
                        CountryId = lead.CountryId,
                        Phone = lead.Phone,
                        Company = company
                    };

                    await _contactRepository.AddAsync(contact);

                    lead.Status = true;
                    lead.CompanyId = company.Id;
                    lead.ContactId = contact.Id;

                    _repository.UpdateAsync(lead);
                    await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                return BaseResponse<Guid>.SuccessResult(request.Id, 200, "The lead has been converted successfully");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
}
