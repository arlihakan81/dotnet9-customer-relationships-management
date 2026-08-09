namespace CRM.Application.Dtos.Deal
{
    public class DealDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid PipelineId { get; set; }
        public bool Status { get; set; }
        public string Value { get; set; } = string.Empty;
        public Guid CurrencyId { get; set; }
        public string? Description { get; set; }
        public Guid StageId { get; set; }
        public Guid? ContactId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid SourceId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ExpectedClosingDate { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
