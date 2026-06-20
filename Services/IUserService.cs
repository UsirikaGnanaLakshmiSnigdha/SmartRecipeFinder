using SmartRecipeFinder.Models;

namespace SmartRecipeFinder.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user);

        Task<User?> LoginAsync(
            string email,
            string password);

        Task<User?> GetUserByIdAsync(int id);
    }
}