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
                Name = request.Name,
                Email = new Domain.ValueObjects.EmailAddress(request.Email),
                Phone = new Domain.ValueObjects.PhoneNumber(request.Phone),
                Company = request.Company,
                Position = request.Position,
                SourceId = request.SourceId,
                OwnerId = request.OwnerId,
                CityId = request.CityId,
                CountryId = request.CountryId
            };
            await _repository.AddAsync(lead);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
