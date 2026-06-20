using Microsoft.AspNetCore.Mvc;
using SmartRecipeFinder.Data;
using SmartRecipeFinder.Models;
using Microsoft.AspNetCore.Authorization;

namespace SmartRecipeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================
        // GET ALL RECIPES
        // =====================================

        [HttpGet("recipes")]
        public IActionResult GetAllRecipes()
        {
            var recipes =
                _context.Recipes.ToList();

            return Ok(recipes);
        }

        // =====================================
        // GET RECIPE BY ID
        // =====================================

        [HttpGet("recipes/{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe =
                _context.Recipes
                .FirstOrDefault(
                    r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // =====================================
        // ADD RECIPE
        // =====================================

        [HttpPost("addrecipe")]
        public IActionResult AddRecipe(
            [FromBody] Recipe recipe)
        {
            _context.Recipes.Add(recipe);

            _context.SaveChanges();

            return Ok(new
            {
                message =
                    "Recipe Added Successfully"
            });
        }

        // =====================================
        // UPDATE RECIPE
        // =====================================

        [HttpPut("updaterecipe/{id}")]
        public IActionResult UpdateRecipe(
            int id,
            [FromBody] Recipe updatedRecipe)
        {
            var recipe =
                _context.Recipes
                .FirstOrDefault(
                    r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            recipe.RecipeName =
                updatedRecipe.RecipeName;

            recipe.Description =
                updatedRecipe.Description;

            recipe.CookingTime =
                updatedRecipe.CookingTime;

            recipe.ImageUrl =
                updatedRecipe.ImageUrl;

            recipe.IngredientsText =
                updatedRecipe.IngredientsText;

            recipe.Instructions =
                updatedRecipe.Instructions;

            recipe.Category =
                updatedRecipe.Category;

            recipe.FoodType =
                updatedRecipe.FoodType;

            _context.SaveChanges();

            return Ok(new
            {
                message =
                    "Recipe Updated Successfully"
            });
        }

        // =====================================
        // DELETE RECIPE
        // =====================================

        [HttpDelete("deleterecipe/{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe =
                _context.Recipes
                .FirstOrDefault(
                    r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);

            _context.SaveChanges();

            return Ok(new
            {
                message =
                    "Recipe Deleted Successfully"
            });
        }

        // =====================================
        // DASHBOARD STATS
        // =====================================

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok(new
            {
                TotalRecipes =
                    _context.Recipes.Count(),

                TotalUsers =
                    _context.Users.Count(),

                TotalFavorites =
                    _context.Favorites.Count()
            });
        }

        // =====================================
        // IMAGE UPLOAD
        // =====================================

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(
            IFormFile file)
        {
            if (file == null ||
                file.Length == 0)
            {
                return BadRequest(
                    "No file uploaded.");
            }

            var uploadsFolder =
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images");

            if (!Directory.Exists(
                uploadsFolder))
            {
                Directory.CreateDirectory(
                    uploadsFolder);
            }

            var fileName =
                Guid.NewGuid()
                + Path.GetExtension(
                    file.FileName);

            var filePath =
                Path.Combine(
                    uploadsFolder,
                    fileName);

            using (var stream =
                new FileStream(
                    filePath,
                    FileMode.Create))
            {
                await file.CopyToAsync(
                    stream);
            }

            return Ok(new
            {
                imageUrl =
                    $"/images/{fileName}"
            });
        }
    }
}