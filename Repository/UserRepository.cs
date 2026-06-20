using Microsoft.EntityFrameworkCore;
using SmartRecipeFinder.Data;
using SmartRecipeFinder.Models;
using SmartRecipeFinder.Repository;
using SmartRecipeFinder.Services;

namespace SmartRecipeFinder.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?>
        GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(
                    u => u.Email == email);
        }

        public async Task<User?>
        GetUserByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(
                    u => u.UserId == id);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}