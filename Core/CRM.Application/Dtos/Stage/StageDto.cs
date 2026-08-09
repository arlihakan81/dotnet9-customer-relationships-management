namespace CRM.Application.Dtos.Stage
{
    public class StageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid PipelineId { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
