using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Lead.Commands.Create
{
    public class CreateLeadCommand : IRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Company { get; set; } = string.Empty;
        public string? Position { get; set; }
        [Required]
        public Guid SourceId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Guid CityId { get; set; }
        [Required]
        public Guid CountryId { get; set; }
    }
}
