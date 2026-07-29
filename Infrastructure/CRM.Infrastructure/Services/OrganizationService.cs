using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CRM.Infrastructure.Services
{
    public class OrganizationService(IHttpContextAccessor httpContextAccessor) : IOrganizationService
    {
        public Guid GetCurrentOrganizationId()
        {
            var organizationId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "organization_id")?.Value;
            if (organizationId == null)
            {
                return Guid.Empty;
            }
            return Guid.Parse(organizationId);
        }

        public Guid GetLoggedInUserId()
        {
            return Guid.Parse(httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public bool IsAuthenticated() => httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }
}
