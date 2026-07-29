using CRM.Application.Interfaces;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Services
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
