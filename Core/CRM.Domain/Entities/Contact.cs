using CRM.Domain.Entities.Commons;
using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities
{
    public class Contact : BaseEntity<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public EmailAddress Email { get; set; } = default!;
        public PhoneNumber Mobile { get; set; } = default!;
        public PhoneNumber? Phone { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? StreetAddress { get; set; }
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
        public string? PostalCode { get; set; }
        public string? State { get; set; }

        public Guid CompanyId { get; set; }


        // Navigation properties
        public virtual Company Company { get; set; } = default!;
        public virtual City City { get; set; } = default!;
        public virtual Country Country { get; set; } = default!;

    }
}
