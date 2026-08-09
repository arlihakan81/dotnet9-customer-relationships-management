namespace CRM.Application.Dtos.ContactStage
{
    public sealed class ContactStageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
