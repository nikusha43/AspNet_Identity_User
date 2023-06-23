using AspIdentityUserApp.Dtos;
using AspIdentityUserApp.Models;

namespace AspIdentityUserApp.Services.Abstraction
{
    public interface IUserRepository
    {
        Task<bool>RegisterUserAsync(User user, string password);
        Task<bool>LoginUserAsync(string email, string password,bool RemmemberMe);
        Task<bool> DeleteUserAsync(string id);
        Task<List<UserDto>> GetAllUsersAsync();

    }
}
