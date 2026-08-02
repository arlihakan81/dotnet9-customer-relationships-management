using CRM.Domain.ValueObjects;

namespace CRM.Application.Dtos.Contact
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public string? Phone { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? StreetAddress { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public string? State { get; set; }

        public string Company { get; set; } = string.Empty;


    }
}
