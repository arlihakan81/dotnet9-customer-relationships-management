using CRM.Domain.Entities.Commons;
using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities
{
    public class Lead : BaseEntity<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public EmailAddress Email { get; set; } = default!;
        public PhoneNumber Phone { get; set; } = default!;
        public string CompanyName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public Guid SourceId { get; set; }
        public Guid OwnerId { get; set; }

        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid IndustryId { get; set; }
        public Guid StageId { get; set; }

        public Guid? CompanyId { get; set; }
        public Guid? ContactId { get; set; }
        public bool Status { get; set; } = false; // if status is true lead converted else open

        // Navigation properties
        public virtual Source Source { get; set; } = default!;
        public virtual User Owner { get; set; } = default!;
        public virtual City City { get; set; } = default!;
        public virtual Country Country { get; set; } = default!;
        public virtual Company? Company { get; set; }
        public virtual Contact? Contact { get; set; }
        public virtual Currency Currency { get; set; } = default!;
        public virtual Industry Industry { get; set; } = default!;
        public virtual ContactStage ContactStage { get; set; } = default!;

    }
}
