using SmartRecipeFinder.Models;

namespace SmartRecipeFinder.Repository
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllRecipesAsync();

        Task<Recipe?> GetRecipeByIdAsync(int id);
    }
}