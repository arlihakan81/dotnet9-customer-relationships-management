using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Repositories
{
    public class ContactStageRepository(AppDbContext context) : Repository<ContactStage>(context), IContactStageRepository
    {
    }
}
