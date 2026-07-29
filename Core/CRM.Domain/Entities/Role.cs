namespace CRM.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation Properties
        public virtual ICollection<User> Users { get; set; } = [];
    }
}
