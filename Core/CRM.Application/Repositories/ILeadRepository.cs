using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface ILeadRepository : IRepository<Lead>
    {
        Task ConvertLeadAsync(Guid leadId);
    }
}
