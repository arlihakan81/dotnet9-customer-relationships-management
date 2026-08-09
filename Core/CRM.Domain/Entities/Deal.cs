using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Deal : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public Guid PipelineId { get; set; }
        public bool Status { get; set; }
        public decimal Value { get; set; }
        public Guid CurrencyId { get; set; }
        public string? Description { get; set; }
        public Guid StageId { get; set; }
        public Guid? ContactId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid SourceId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ExpectedClosingDate { get; set; }


        public virtual Pipeline Pipeline { get; set; } = default!;
        public virtual Stage Stage { get; set; } = default!;
        public virtual Contact? Contact { get; set; }
        public virtual Company Company { get; set; } = default!;
        public virtual Currency Currency { get; set; } = default!;
        public virtual User Owner { get; set; } = default!;
        public virtual Source Source { get; set; } = default!;




    }
}
