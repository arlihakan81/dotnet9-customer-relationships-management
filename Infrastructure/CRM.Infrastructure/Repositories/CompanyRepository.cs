using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class CompanyRepository(AppDbContext context) : Repository<Company>(context), ICompanyRepository
    {
        private readonly AppDbContext _context = context;

        public override async Task<IEnumerable<Company>?> GetAllAsync(int page, int pageSize, Expression<Func<Company, bool>>? expression = null)
        {
            return await _context.Companies.Include(c => c.City).Include(c => c.Country)
                .Where(expression ?? (c => true))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override async Task<Company?> GetAsync(Expression<Func<Company, bool>> expression)
        {
            return await _context.Companies.Include(c => c.City).Include(c => c.Country)
                .FirstOrDefaultAsync(expression);
        }

        public override async Task<Company?> GetByIdAsync(Guid id)
        {
            return await _context.Companies.Include(c => c.City).Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
        }


    }
}
