using SmartRecipeFinder.Models;

namespace SmartRecipeFinder.Data
{
    public static class DbSeeder
    {
        public static void Seed(
            ApplicationDbContext context)
        {
            if (context.Recipes.Any())
                return;

            var egg =
                new Ingredient
                {
                    IngredientName = "egg"
                };

            var onion =
                new Ingredient
                {
                    IngredientName = "onion"
                };

            context.Ingredients
                .AddRange(egg, onion);

            context.SaveChanges();

            var omelette = new Recipe
            {
                RecipeName = "Omelette",
                Description = "Egg Omelette",
                CookingTime = "10 Minutes",
                ImageUrl = "/images/omelette.jpg",
                Instructions = "Beat eggs and fry."
            };

            context.Recipes
                .Add(omelette);

            context.SaveChanges();

            context.RecipeIngredients
                .AddRange(
                    new RecipeIngredient
                    {
                        RecipeId =
                            omelette.RecipeId,
                        IngredientId =
                            egg.IngredientId
                    },
                    new RecipeIngredient
                    {
                        RecipeId =
                            omelette.RecipeId,
                        IngredientId =
                            onion.IngredientId
                    });

            var milkShake = new Recipe
            {
                RecipeName = "Milk Shake",
                Description = "Sweet Milk Shake",
                CookingTime = "5 Minutes",
                ImageUrl = "/images/milkshake.jpg",
                Instructions =
"Blend milk and sugar."
            };

            var tomatoSoup = new Recipe
            {
                RecipeName = "Tomato Soup",
                Description = "Hot Tomato Soup",
                CookingTime = "20 Minutes",
                ImageUrl = "/images/tomatosoup.jpg",
                Instructions =
                    "Boil tomatoes and blend."
            };
            var friedRice = new Recipe
            {
                RecipeName = "Fried Rice",
                Description = "Vegetable Fried Rice",
                CookingTime = "25 Minutes",
                ImageUrl = "/images/friedrice.jpg",
                Instructions =
                    "Cook rice and stir fry vegetables."
            };
            var sandwich = new Recipe
            {
                RecipeName = "Vegetable Sandwich",
                Description = "Quick Sandwich",
                CookingTime = "10 Minutes",
                ImageUrl = "/images/sandwich.jpg",
                Instructions =
                    "Layer vegetables between bread slices."
            };
            context.SaveChanges();
        }
    }
}