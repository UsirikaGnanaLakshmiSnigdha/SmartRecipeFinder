using SmartRecipeFinder.Models;

namespace SmartRecipeFinder.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeMatchResult>>
            SearchRecipesAsync(string ingredients);

        Task<Recipe?>
            GetRecipeByIdAsync(int id);
    }
}