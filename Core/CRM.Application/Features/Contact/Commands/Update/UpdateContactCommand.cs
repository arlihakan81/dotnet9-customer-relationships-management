using CRM.Application.Features.Contact.Commands.Create;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Contact.Commands.Update
{
    public class UpdateContactCommand : CreateContactCommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
