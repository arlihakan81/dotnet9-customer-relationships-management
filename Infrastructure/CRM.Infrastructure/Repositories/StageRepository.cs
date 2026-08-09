using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Repositories
{
    public class StageRepository(AppDbContext context) : Repository<Stage>(context), IStageRepository
    {
    }
}
