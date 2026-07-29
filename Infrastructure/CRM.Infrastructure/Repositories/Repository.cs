using CRM.Application.Repositories;
using CRM.Domain.Entities.Commons;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : BaseEntity<Guid>
    {
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity!.IsDeleted = true;
        }

        public async Task<IEnumerable<T>?> GetAllAsync(int page, int pageSize, Expression<Func<T, bool>>? expression = null)
        {
            return expression is null ? await context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync() : await context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
