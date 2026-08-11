using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<bool> IsUniqueEmailAddressAsync(string email, Guid? excludeId = null);
        Task<bool> IsUniqueMobileOrPhoneAsync(string phone, Guid? excludeId = null);


    }
}
