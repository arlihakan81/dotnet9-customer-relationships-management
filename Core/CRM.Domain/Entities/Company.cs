using CRM.Domain.Entities.Commons;
using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities
{
    public class Company : BaseEntity<Guid>
    {
        public string? AvatarUrl { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public EmailAddress Email { get; set; } = default!;
        public PhoneNumber Phone { get; set; } = default!;
        public PhoneNumber? AlternatePhone { get; set; }
        public PhoneNumber? Fax { get; set; }
        public string? Website { get; set; }
        public Guid SourceId { get; set; }
        public Guid CurrencyId { get; set; }
        public string? StreetAddress { get; set; }
        public Guid CityId { get; set; }
        public string? State { get; set; }
        public Guid CountryId { get; set; }
        public string? FacebookUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? X_Url { get; set; }
        public string? WhatsappUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? Description { get; set; }
        public Guid OwnerId { get; set; }
        public bool Status { get; set; } = true;
        public Guid IndustryId { get; set; }

        // Navigation properties
        public virtual User Owner { get; set; } = null!;
        public virtual Source Source { get; set; } = null!;
        public virtual Currency Currency { get; set; } = null!;
        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual Industry Industry { get; set; } = default!;
   
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    }
}
