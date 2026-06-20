using Microsoft.AspNetCore.Mvc;
using SmartRecipeFinder.Services;

namespace SmartRecipeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeApiController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecipeApiController(IRecipeService service)
        {
            _service = service;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string ingredients)
        {
            var results =
                await _service.SearchRecipesAsync(ingredients);

            var response = results.Select(r => new
            {
                recipeId = r.Recipe.RecipeId,
                recipeName = r.Recipe.RecipeName,
                description = r.Recipe.Description,
                cookingTime = r.Recipe.CookingTime,
                imageUrl = r.Recipe.ImageUrl,
                ingredientsText = r.Recipe.IngredientsText,
                instructions = r.Recipe.Instructions,
                category = r.Recipe.Category,
                foodType = r.Recipe.FoodType,
                matchPercentage = r.MatchPercentage
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var recipe =
                await _service
                .GetRecipeByIdAsync(id);

            if (recipe == null)
                return NotFound();

            return Ok(new
            {
                recipeId = recipe.RecipeId,
                recipeName = recipe.RecipeName,
                description = recipe.Description,
                cookingTime = recipe.CookingTime,
                imageUrl = recipe.ImageUrl,
                ingredientsText = recipe.IngredientsText,
                instructions = recipe.Instructions
            });
        }
    }
}