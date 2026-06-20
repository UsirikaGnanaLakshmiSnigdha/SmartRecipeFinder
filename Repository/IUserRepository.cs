
using SmartRecipeFinder.Models;
using SmartRecipeFinder.Repository;
using SmartRecipeFinder.Services;

namespace SmartRecipeFinder.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByIdAsync(int id);

        Task AddUserAsync(User user);

        Task SaveChangesAsync();
    }
}