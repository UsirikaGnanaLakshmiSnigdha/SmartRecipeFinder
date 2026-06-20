namespace SmartRecipeFinder.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; } = string.Empty;

        public ICollection<RecipeIngredient> RecipeIngredients
        {
            get;
            set;
        } = new List<RecipeIngredient>();
    }
}