namespace CRM.Domain.Entities
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public Guid CountryId { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual Country Country { get; set; } = null!;
    }
}
