using SmartRecipeFinder.Models;
using SmartRecipeFinder.Repository;
using SmartRecipeFinder.Services;

namespace SmartRecipeFinder.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool>
        RegisterUserAsync(User user)
        {
            var existingUser =
                await _userRepository
                .GetUserByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return false;
            }

            await _userRepository
                .AddUserAsync(user);

            await _userRepository
                .SaveChangesAsync();

            return true;
        }

        public async Task<User?>
        LoginAsync(
            string email,
            string password)
        {
            var user =
                await _userRepository
                .GetUserByEmailAsync(email);

            if (user == null)
                return null;

            if (user.PasswordHash != password)
                return null;

            return user;
        }

        public async Task<User?>
        GetUserByIdAsync(int id)
        {
            return await _userRepository
                .GetUserByIdAsync(id);
        }
    }
}