namespace SmartRecipeFinder.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public Recipe Recipe { get; set; } = null!;

        public Ingredient Ingredient { get; set; } = null!;
    }
}