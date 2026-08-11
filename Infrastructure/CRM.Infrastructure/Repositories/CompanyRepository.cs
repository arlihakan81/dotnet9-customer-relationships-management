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
            return await _context.Companies.Include(c => c.City).Include(c => c.Country).Include(c => c.Industry)
                .Where(expression ?? (c => true))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override async Task<Company?> GetAsync(Expression<Func<Company, bool>> expression)
        {
            return await _context.Companies.Include(c => c.City).Include(c => c.Country).Include(c => c.Industry)
                .FirstOrDefaultAsync(expression);
        }

        public override async Task<Company?> GetByIdAsync(Guid id)
        {
            return await _context.Companies.Include(c => c.City).Include(c => c.Country)
                .Include(c => c.Industry)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsUniqueEmailAddressAsync(string email, Guid? excludeId = null)
        {
            return excludeId is null ?
                !await _context.Companies.AnyAsync(c => c.Email.Value == email)
                : !await _context.Companies.AnyAsync(c => c.Email.Value == email && c.Id != excludeId);
        }

        public async Task<bool> IsUniqueNameAsync(string name, Guid? excludeId = null)
        {
            return excludeId is null ?
                !await _context.Companies.AnyAsync(c => c.Name == name)
                : !await _context.Companies.AnyAsync(c => c.Name == name && c.Id != excludeId);
        }

        public async Task<bool> IsUniquePhoneOrMobileAsync(string phone, Guid? excludeId = null)
        {
            return excludeId is null ?
                !await _context.Companies.AnyAsync(c => c.Phone.Value == phone) :
                !await _context.Companies.AnyAsync(c => c.Phone.Value == phone && c.Id != excludeId);
        }

        public async Task<bool> IsUniqueTitleAsync(string title, Guid? excludeId = null)
        {
            return excludeId is null ?
                !await _context.Companies.AnyAsync(c => c.Title == title) :
                !await _context.Companies.AnyAsync(c => c.Title == title && c.Id != excludeId);
        }
    }
}
