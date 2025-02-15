using Microsoft.AspNetCore.Identity;

namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IdentityUser?> GetUser();
    }
}
