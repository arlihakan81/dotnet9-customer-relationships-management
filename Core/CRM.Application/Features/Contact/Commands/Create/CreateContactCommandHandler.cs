using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using MediatR;

namespace CRM.Application.Features.Contact.Commands.Create
{
    public class CreateContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateContactCommand>
    {
        private readonly IContactRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Domain.Entities.Contact
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = new Domain.ValueObjects.EmailAddress(request.Email),
                Mobile = new Domain.ValueObjects.PhoneNumber(request.Mobile),
                Phone = request.Phone is not null ? new Domain.ValueObjects.PhoneNumber(request.Phone) : null,
                Title = request.Title,
                StreetAddress = request.StreetAddress,
                CityId = request.CityId,
                CountryId = request.CountryId,
                PostalCode = request.PostalCode,
                State = request.State,
                CompanyId = request.CompanyId
            };
            await _repository.AddAsync(contact);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
