namespace SmartRecipeFinder.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }

        public int UserId { get; set; }

        public int RecipeId { get; set; }

        public User? User { get; set; }

        public Recipe? Recipe { get; set; }
    }
}