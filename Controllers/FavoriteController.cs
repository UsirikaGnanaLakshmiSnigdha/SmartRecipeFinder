using Microsoft.AspNetCore.Mvc;
using SmartRecipeFinder.Data;
using SmartRecipeFinder.Models;

namespace SmartRecipeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoriteController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public IActionResult AddFavorite(
            Favorite favorite)
        {
            var existing =
                _context.Favorites
                .FirstOrDefault(
                    x =>
                    x.UserId ==
                    favorite.UserId
                    &&
                    x.RecipeId ==
                    favorite.RecipeId);

            if (existing != null)
            {
                return BadRequest(
                    "Already Exists");
            }

            _context.Favorites
                .Add(favorite);

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("{userId}")]
        public IActionResult GetFavorites(
            int userId)
        {
            var favorites =
                _context.Favorites
                .Where(
                    x =>
                    x.UserId ==
                    userId)
                .ToList();

            return Ok(favorites);
        }

        [HttpDelete("remove")]
        public IActionResult RemoveFavorite(
    int userId,
    int recipeId)
        {
            var favorite =
                _context.Favorites
                .FirstOrDefault(
                    x =>
                    x.UserId == userId
                    &&
                    x.RecipeId == recipeId);

            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(
                favorite);

            _context.SaveChanges();

            return Ok();
        }
    }
}