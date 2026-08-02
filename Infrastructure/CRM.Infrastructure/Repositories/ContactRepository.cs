using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class ContactRepository(AppDbContext context) : Repository<Contact>(context), IContactRepository
    {
        private readonly AppDbContext _context = context;

        public override async Task<IEnumerable<Contact>?> GetAllAsync(int page, int pageSize, Expression<Func<Contact, bool>>? expression = null)
        {
            return await _context.Set<Contact>()
                .Include(c => c.Company)
                .Include(c => c.City)
                .Include(c => c.Country)
                .Where(expression ?? (x => true))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override async Task<Contact?> GetAsync(Expression<Func<Contact, bool>> expression)
        {
            return await _context.Contacts.Include(c => c.Company)
                .Include(c => c.City)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(expression);
        }

        public override async Task<Contact?> GetByIdAsync(Guid id)
        {
            return await _context.Contacts.Include(c => c.Company)
                .Include(c => c.City)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
        }



    }
}
