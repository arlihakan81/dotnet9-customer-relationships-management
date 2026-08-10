using CRM.Application.Dtos.Contact;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Contact.Commands.Create
{
    public class CreateContactCommand : IRequest<BaseResponse<ContactDto>>
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required] 
        public string Mobile { get; set; } = string.Empty;
        public string? Phone { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? StreetAddress { get; set; }
        [Required]
        public Guid CityId { get; set; }
        [Required]
        public Guid CountryId { get; set; }
        public string? PostalCode { get; set; }
        public string? State { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
    }
}
