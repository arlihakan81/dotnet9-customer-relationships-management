namespace CRM.Domain.Entities.Commons
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public Guid CreatedById { get; set; }
        public Guid? ModifiedById { get; set; }
        public Guid? DeletedById { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual User? ModifiedBy { get; set; }
        public virtual User? DeletedBy { get; set; }
        public virtual User? CreatedBy { get; set; }

        public Guid OrganizationId { get; set; }

        public Organization Organization { get; set; } = null!;
    }
}
