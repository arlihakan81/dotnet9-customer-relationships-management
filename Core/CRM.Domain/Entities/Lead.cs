using CRM.Domain.Entities.Commons;
using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities
{
    public class Lead : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public EmailAddress Email { get; set; } = default!;
        public PhoneNumber Phone { get; set; } = default!;
        public string Company { get; set; } = string.Empty;
        public string? Position { get; set; }
        public Guid SourceId { get; set; }
        public Guid OwnerId { get; set; }

        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }


        // Navigation properties
        public virtual Source Source { get; set; } = default!;
        public virtual User Owner { get; set; } = default!;
        public virtual City City { get; set; } = default!;
        public virtual Country Country { get; set; } = default!;





    }
}
