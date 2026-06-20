namespace SmartRecipeFinder.Models
{
    public class RecipeMatchResult
    {
        public Recipe Recipe { get; set; } = null!;

        public int TotalIngredients { get; set; }

        public int MatchedIngredients { get; set; }

        public double MatchPercentage { get; set; }
    }
}