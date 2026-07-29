using CRM.Application.Requests;
using CRM.Application.Responses;

namespace CRM.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task RegisterAsync(RegisterRequest request);
    }
}
