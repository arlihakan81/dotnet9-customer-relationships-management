using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Stage : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public Guid PipelineId { get; set; }

        public virtual Pipeline Pipeline { get; set; } = default!;
        public virtual ICollection<Deal> Deals { get; set; } = [];

    }
}
