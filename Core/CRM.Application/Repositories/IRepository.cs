using CRM.Domain.Entities.Commons;
using System.Linq.Expressions;

namespace CRM.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity<Guid>
    {
        Task<IEnumerable<T>?> GetAllAsync(int page, int pageSize, Expression<Func<T, bool>>? expression = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);

        Task<T?> GetByIdAsync(Guid id);

        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        Task DeleteAsync(Guid id);

    }
}
