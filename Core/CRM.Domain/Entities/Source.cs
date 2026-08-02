using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Source : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Status { get; set; } = true;
        // Navigation properties
        public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
