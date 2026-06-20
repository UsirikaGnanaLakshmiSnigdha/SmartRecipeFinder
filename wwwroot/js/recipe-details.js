const params =
    new URLSearchParams(
        window.location.search
    );

const recipeId =
    params.get("id");

loadRecipe();

async function loadRecipe()
{
    const response =
        await fetch(
            `/api/RecipeApi/${recipeId}`
        );

    const recipe =
        await response.json();

    document
        .getElementById("recipeDetails")
        .innerHTML = `

        <img
            src="${recipe.imageUrl}"
            class="details-image">

        <h1>
            ${recipe.recipeName}
        </h1>

        <p>
            ${recipe.description}
        </p>

        <h3>
            Cooking Time
        </h3>

        <p>
            ${recipe.cookingTime}
        </p>

        <h3>
            Ingredients
        </h3>

        <p>
            ${recipe.ingredientsText}
        </p>

        <h3>
            Instructions
        </h3>

        <p>
            ${recipe.instructions}
        </p>
    `;
}