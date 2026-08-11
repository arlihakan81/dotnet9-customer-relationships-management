using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<bool> IsUniqueNameAsync(string name, Guid? excludeId = null);
        Task<bool> IsUniqueTitleAsync(string title, Guid? excludeId = null);

        Task<bool> IsUniqueEmailAddressAsync(string email, Guid? excludeId = null);

        Task<bool> IsUniquePhoneOrMobileAsync(string phone, Guid? excludeId = null);
    }
}
