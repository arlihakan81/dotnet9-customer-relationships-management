using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class ContactStage : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public virtual ICollection<Lead> Leads { get; set; } = [];




    }
}
