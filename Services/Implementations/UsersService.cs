using Microsoft.AspNetCore.Identity;
using PPI_Challenge_API.Services.Interfaces;
using static PPI_Challenge_API.Services.Implementations.UsersService;

namespace PPI_Challenge_API.Services.Implementations
{
    public class UsersService(IHttpContextAccessor httpContextAccessor,
       UserManager<IdentityUser> userManager) : IUsersService
    {
        public async Task<IdentityUser?> GetUser()
        {
            var emailClaim = httpContextAccessor.HttpContext!
                .User.Claims.Where(x => x.Type == "email").FirstOrDefault();

            if (emailClaim is null)
            {
                return null;
            }

            var email = emailClaim.Value;
            return await userManager.FindByEmailAsync(email);
        }
    }
}
