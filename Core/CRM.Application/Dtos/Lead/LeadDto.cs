using CRM.Domain.ValueObjects;

namespace CRM.Application.Dtos.Lead
{
    public class LeadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string? Position { get; set; }
        public Guid SourceId { get; set; }
        public Guid OwnerId { get; set; }

        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
    }
}
