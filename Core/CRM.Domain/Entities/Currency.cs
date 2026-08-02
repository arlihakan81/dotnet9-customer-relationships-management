namespace CRM.Domain.Entities
{
    public class Currency
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
