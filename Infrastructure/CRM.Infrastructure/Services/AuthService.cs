using CRM.Application.Interfaces;
using CRM.Application.Requests;
using CRM.Application.Responses;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Services
{
    public class AuthService(AppDbContext context, ITokenService tokenService) : IAuthService
    {
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await GetByEmailAsync(request.Email);
            if(user is not null)
            {
                if(!user.IsDeleted)
                {
                    if(new PasswordHasher<User>().VerifyHashedPassword(user,user.PasswordHash,request.Password) == PasswordVerificationResult.Success)
                    {
                        var token = tokenService.GenerateToken(user);
                        return new LoginResponse
                        {
                            Success = true,
                            AccessToken = token,
                            Error = null!
                        };
                    }
                }
            }
            return new LoginResponse
            {
                Success = false,
                AccessToken = null!,
                Error = "An error occured"
            };
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            context.Organizations.Add(new Organization
            {
                Name = request.Email.Split('@')[1],
                Domain = request.Email.Split('@')[1],
                Users = [
                    new User {
                        Name = request.Name,
                        Email = request.Email,
                        PasswordHash = new PasswordHasher<User>().HashPassword(null!, request.Password),
                        Role = context.Roles.FirstOrDefault(r => r.Name == "Admin")!
                    }
                ]
            });
            await context.SaveChangesAsync();
        }

        private async Task<User?> GetByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
