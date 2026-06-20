namespace SmartRecipeFinder.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public string? RecipeName { get; set; } 
        public string? Description { get; set; } 

        public string? CookingTime { get; set; } 

        public string? ImageUrl { get; set; } 

        public string? Instructions { get; set; } 

        public string? IngredientsText { get; set; }

        public string? FoodType { get; set; }
        public string? Category { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients
        {
            get;
            set;
        } = new List<RecipeIngredient>();
    }
}