namespace CRM.Domain.Entities
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; } = [];

    }
}
