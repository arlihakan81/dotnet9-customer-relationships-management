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

        public async Task ConvertLeadToCompanyAsync(Guid leadId)
        {
            var lead = await GetByIdAsync(leadId);
            if(lead is not null)
            {
                var company = new Company
                {
                    Name = lead.Name,
                    Title = lead.Name,
                    CityId = lead.CityId,
                    CountryId = lead.CountryId,
                    Phone = lead.Phone,
                    Email = lead.Email,
                    CurrencyId = _context.Currencies.FirstOrDefault(_ => _.Symbol == "₺")!.Id,
                    SourceId = lead.SourceId,
                    OwnerId = lead.OwnerId,
                    Status = true,
                    Contacts = [
                        new Contact {
                            FirstName = lead.Name,
                            LastName = lead.Name,
                            Title = lead.Position!,
                            CityId = lead.CityId,
                            CountryId = lead.CountryId,
                            Email = lead.Email,
                            Mobile = lead.Phone,
                        }    
                    ]
                };
                _context.Companies.Add(company);
            }            
        }

        public override async Task<IEnumerable<Lead>?> GetAllAsync(int page, int pageSize, Expression<Func<Lead, bool>>? expression = null)
        {
            return await _context.Leads.Include(l => l.City).Include(l => l.Country)
                .Where(expression ?? (x => true))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override async Task<Lead?> GetByIdAsync(Guid id)
        {
            return await _context.Leads.Include(_ => _.City).Include(_ => _.Country)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
