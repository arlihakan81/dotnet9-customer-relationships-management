using CRM.Application.Features.Contact.Commands.Update;
using FluentValidation;

namespace CRM.Application.Validations.Contact
{
    public sealed class UpdateContactValidator : AbstractValidator<UpdateContactCommand>
    {

        public UpdateContactValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("First name is required and cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Last name is required and cannot exceed 50 characters.");
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is required and must be a valid email address.");




        }


    }
}
