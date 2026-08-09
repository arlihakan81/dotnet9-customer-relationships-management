using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class LeadRepository(AppDbContext context) : Repository<Lead>(context), ILeadRepository
    {
        private readonly AppDbContext _context = context;

        public async Task ConvertLeadAsync(Guid leadId)
        {
            await _context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Lead>?> GetAllAsync(int page, int pageSize, Expression<Func<Lead, bool>>? expression = null)
        {
            return await _context.Leads.Include(l => l.City).Include(l => l.Country).Include(l => l.Industry)
                .Where(expression ?? (x => true))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override async Task<Lead?> GetByIdAsync(Guid id)
        {
            return await _context.Leads.Include(_ => _.City).Include(_ => _.Country).Include(l => l.Industry)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
