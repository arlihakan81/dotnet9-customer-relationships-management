using CRM.Application.Features.Contact.Commands.Create;
using FluentValidation;

namespace CRM.Application.Validations.Contact
{
    public sealed class CreateContactValidator : AbstractValidator<CreateContactCommand>
    {

        public CreateContactValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("First name is required and cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Last name is required and cannot exceed 50 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("Phone is required and cannot exceed 20 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is required and must be a valid email address.");




        }


    }
}
