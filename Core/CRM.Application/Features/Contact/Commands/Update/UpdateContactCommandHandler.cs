using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using FluentValidation;
using MediatR;

namespace CRM.Application.Features.Contact.Commands.Update
{
    public sealed class UpdateContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateContactCommand> validator) : IRequestHandler<UpdateContactCommand, BaseResponse<ContactDto>>
    {
        private readonly IContactRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<UpdateContactCommand> _validator = validator;

        public async Task<BaseResponse<ContactDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var valid = await _validator.ValidateAsync(request, cancellationToken);

            if (!valid.IsValid)
                return BaseResponse<ContactDto>.FailureResult("Validation failed", string.Join(", ", valid.Errors.Select(x => x.ErrorMessage)));

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

            var data = _mapper.Map<ContactDto>(contact);

            return BaseResponse<ContactDto>.SuccessResult(data, "Contact has been updated successfully");
        }
    }
}
