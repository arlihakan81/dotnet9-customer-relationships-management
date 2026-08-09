using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class DealRepository(AppDbContext context) : Repository<Deal>(context), IDealRepository
    {
        private readonly AppDbContext _context = context;

        public override async Task<IEnumerable<Deal>?> GetAllAsync(int page, int pageSize, Expression<Func<Deal, bool>>? expression = null)
        {
            return await _context.Deals.Include(d => d.Currency)
                .Where(expression ?? (x => true))
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }


    }
}
