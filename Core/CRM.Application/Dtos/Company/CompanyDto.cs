namespace CRM.Application.Dtos.Company
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string? AvatarUrl { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? AlternatePhone { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
        public Guid SourceId { get; set; } // Add a property for the source of the company (e.g., referral, website, etc.)
        public Guid CurrencyId { get; set; } // Add a property for the currency used by the company (e.g., USD, EUR, etc.)
        public string? StreetAddress { get; set; }
        public string City { get; set; } = string.Empty;
        public string? State { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string? FacebookUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? X_Url { get; set; }
        public string? WhatsappUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public Guid OwnerId { get; set; }
        public bool Status { get; set; }

    }
}
