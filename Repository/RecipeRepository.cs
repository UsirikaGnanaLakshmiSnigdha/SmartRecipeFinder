using Microsoft.EntityFrameworkCore;
using SmartRecipeFinder.Data;
using SmartRecipeFinder.Models;

namespace SmartRecipeFinder.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .ToListAsync();
        }
        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes
                .FirstOrDefaultAsync(
                    r => r.RecipeId == id);
        }
    }
}