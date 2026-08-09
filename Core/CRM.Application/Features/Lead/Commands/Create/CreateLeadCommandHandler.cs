using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using MediatR;

namespace CRM.Application.Features.Lead.Commands.Create
{
    public sealed class CreateLeadCommandHandler(ILeadRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateLeadCommand>
    {
        private readonly ILeadRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = new Domain.Entities.Lead
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = new Domain.ValueObjects.EmailAddress(request.Email),
                Phone = new Domain.ValueObjects.PhoneNumber(request.Phone),
                CompanyName = request.Company,
                JobTitle = request.JobTitle,
                SourceId = request.SourceId,
                CurrencyId = request.CurrencyId,
                OwnerId = request.OwnerId,
                CityId = request.CityId,
                CountryId = request.CountryId,
                IndustryId = request.IndustryId
            };
            await _repository.AddAsync(lead);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
