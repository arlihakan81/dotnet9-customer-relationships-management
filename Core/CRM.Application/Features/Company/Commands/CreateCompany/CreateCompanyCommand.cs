using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Company.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest
    {
        public string? AvatarUrl { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        public string? AlternatePhone { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }

        [Required]
        public string Source { get; set; } = string.Empty;
        [Required]
        public string Currency { get; set; } = string.Empty;
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? FacebookUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? X_Url { get; set; }
        public string? WhatsappUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? Description { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public bool Status { get; set; } = true;



    }
}
