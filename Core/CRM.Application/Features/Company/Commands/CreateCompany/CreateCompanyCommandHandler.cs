using AutoMapper;
using CRM.Application.Dtos.Company;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using FluentValidation;
using MediatR;

namespace CRM.Application.Features.Company.Commands.CreateCompany
{
    public sealed class CreateCompanyCommandHandler(ICompanyRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCompanyCommand> validator) : IRequestHandler<CreateCompanyCommand, BaseResponse<CompanyDto>>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private IValidator<CreateCompanyCommand> _validator = validator;

        public async Task<BaseResponse<CompanyDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BaseResponse<CompanyDto>.FailureResult("Validation Failed", 400, string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            if (!await _repository.IsUniqueNameAsync(request.Name))
            {
                return BaseResponse<CompanyDto>.FailureResult("Validation Failed", 400, $"{request.Name} named company already saved");
            }

            if (!await _repository.IsUniqueTitleAsync(request.Title))
            {
                return BaseResponse<CompanyDto>.FailureResult("Validation Failed", 400, $"{request.Title} named company already saved");
            }

            if(!await _repository.IsUniqueEmailAddressAsync(request.Email))
            {
                return BaseResponse<CompanyDto>.FailureResult("Validation Failed", 400, $"{request.Email} mail addressed company already saved");
            }

            if(!await _repository.IsUniquePhoneOrMobileAsync(request.Phone))
            {
                return BaseResponse<CompanyDto>.FailureResult("Validation Failed", 400, $"{request.Phone} phone number already saved");
            }

            var company = new Domain.Entities.Company
            {
                AvatarUrl = request.AvatarUrl,
                Name = request.Name,
                Title = request.Title,
                Email = new Domain.ValueObjects.EmailAddress(request.Email),
                Phone = new Domain.ValueObjects.PhoneNumber(request.Phone),
                AlternatePhone = request.AlternatePhone is not null ? new Domain.ValueObjects.PhoneNumber(request.AlternatePhone) : null,
                CityId = request.CityId,
                CountryId = request.CountryId,
                CurrencyId = request.CurrencyId,
                SourceId = request.SourceId,
                IndustryId = request.IndustryId,
                Description = request.Description,
                Fax = request.Fax is not null ? new Domain.ValueObjects.PhoneNumber(request.Fax) : null,
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
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            company = await _repository.GetByIdAsync(company.Id);

            return BaseResponse<CompanyDto>.SuccessResult(_mapper.Map<CompanyDto>(company), 201, "New company has been added successfully");
        }
    }
}
