using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using MediatR;

namespace CRM.Application.Features.Contact.Commands.Update
{
    public class UpdateContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateContactCommand>
    {
        private readonly IContactRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id);
            if (contact is null)
            {
                throw new Exception($"Contact with Id {request.Id} not found.");
            }
            contact.FirstName = request.FirstName;
            contact.LastName = request.LastName;
            contact.Email = new Domain.ValueObjects.EmailAddress(request.Email);
            contact.Mobile = new Domain.ValueObjects.PhoneNumber(request.Mobile);
            contact.Phone = string.IsNullOrWhiteSpace(request.Phone) ? null : new Domain.ValueObjects.PhoneNumber(request.Phone);
            contact.Title = request.Title;
            contact.StreetAddress = request.StreetAddress;
            contact.CityId = request.CityId;
            contact.CountryId = request.CountryId;
            contact.PostalCode = request.PostalCode;
            contact.State = request.State;
            contact.CompanyId = request.CompanyId;
            _repository.UpdateAsync(contact);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
