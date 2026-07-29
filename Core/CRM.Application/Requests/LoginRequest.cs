using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterRequest : LoginRequest
    {
        public string Name { get; set; } = string.Empty;
        [Compare(nameof(Password))]
        public string ConfirmPassword {  get; set; } = string.Empty;
    }


}
