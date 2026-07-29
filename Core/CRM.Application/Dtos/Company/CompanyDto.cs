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
        public string Source { get; set; } = string.Empty;
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


    }
}
