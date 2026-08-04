using CRM.Application.Features.Company.Commands.CreateCompany;
using FluentValidation;

namespace CRM.Application.Validations.Company
{
    public sealed class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Name is required and cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100)
                .WithMessage("Invalid email address.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("Phone is required and cannot exceed 20 characters.");

            RuleFor(x => x.SourceId)
                .NotEmpty()
                .WithMessage("SourceId is required.");

            RuleFor(x => x.CurrencyId)
                .NotEmpty()
                .WithMessage("CurrencyId is required.");

            RuleFor(x => x.OwnerId)
                .NotEmpty()
                .WithMessage("OwnerId is required.");

            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage("CityId is required.");

            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("CountryId is required.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("Status is required.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Title is required and cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(x => x.AlternatePhone)
                .MaximumLength(20)
                .WithMessage("AlternatePhone cannot exceed 20 characters.");
        }


    }
}
