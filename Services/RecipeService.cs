using SmartRecipeFinder.Models;
using SmartRecipeFinder.Repository;

namespace SmartRecipeFinder.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;

        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RecipeMatchResult>>
            SearchRecipesAsync(string ingredients)
        {
            var recipes =
                await _repository.GetAllRecipesAsync();

            var results =
                new List<RecipeMatchResult>();

            // If no ingredients entered
            if (string.IsNullOrWhiteSpace(ingredients))
            {
                return recipes.Select(r =>
                    new RecipeMatchResult
                    {
                        Recipe = r,
                        MatchPercentage = 0
                    })
                    .ToList();
            }

            var userIngredients =
                ingredients
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim().ToLower())
                .ToList();

            foreach (var recipe in recipes)
            {
                if (string.IsNullOrWhiteSpace(
                    recipe.IngredientsText))
                {
                    continue;
                }

                var recipeIngredients =
                    recipe.IngredientsText
                    .Split(',',
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim().ToLower())
                    .ToList();

                int matchedCount =
                    recipeIngredients.Count(
                        ingredient =>
                        userIngredients.Contains(
                            ingredient));

                if (matchedCount > 0)
                {
                    double matchPercentage =
                        ((double)matchedCount /
                         recipeIngredients.Count) * 100;

                    results.Add(
                        new RecipeMatchResult
                        {
                            Recipe = recipe,
                            MatchPercentage =
                                matchPercentage
                        });
                }
            }

            return results
                .OrderByDescending(
                    x => x.MatchPercentage)
                .ToList();
        }

        public async Task<Recipe?>
            GetRecipeByIdAsync(int id)
        {
            return await _repository
                .GetRecipeByIdAsync(id);
        }
    }
}