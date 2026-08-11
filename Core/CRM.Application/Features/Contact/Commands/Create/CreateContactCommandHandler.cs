using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using CRM.Application.Validations.Contact;
using FluentValidation;
using MediatR;

namespace CRM.Application.Features.Contact.Commands.Create
{
    public sealed class CreateContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateContactCommand> validator) : IRequestHandler<CreateContactCommand, BaseResponse<ContactDto>>
    {
        private readonly IContactRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreateContactCommand> _validator = validator;

        public async Task<BaseResponse<ContactDto>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BaseResponse<ContactDto>.FailureResult("Validation failed", 400, string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            if (!await _repository.IsUniqueEmailAddressAsync(request.Email))
                return BaseResponse<ContactDto>.FailureResult("Validation Failed", 400, $"{request.Email} already in use");
            if (!await _repository.IsUniqueMobileOrPhoneAsync(request.Mobile))
                return BaseResponse<ContactDto>.FailureResult("Validation Failed", 400, $"{request.Mobile} already in use");

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

            contact = await _repository.GetByIdAsync(contact.Id);

            var data = _mapper.Map<ContactDto>(contact);

            return BaseResponse<ContactDto>.SuccessResult(data, 200, "Contact has been added successfully");
        }
    }
}
