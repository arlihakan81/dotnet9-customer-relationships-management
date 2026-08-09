namespace CRM.Application.Dtos.Pipeline
{
    public class PipelineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
