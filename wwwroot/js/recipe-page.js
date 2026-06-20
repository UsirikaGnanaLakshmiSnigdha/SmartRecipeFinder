loadAllRecipes();

async function loadAllRecipes()
{
    const response =
        await fetch(
            "/api/RecipeApi/search?ingredients="
        );

    const recipes =
        await response.json();

    displayRecipes(recipes);
}