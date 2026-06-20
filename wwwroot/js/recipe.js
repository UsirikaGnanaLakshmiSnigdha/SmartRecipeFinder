let allRecipes = [];

window.onload = function () {
    loadRecipes();
};

async function loadRecipes() {
    try {
        const response =
            await fetch(
                "/api/Admin/recipes"
            );

        allRecipes =
            await response.json();

        displayRecipes(
            allRecipes
        );
    }
    catch (error) {
        console.error(error);

        document.getElementById(
            "results"
        ).innerHTML =
            "<h2>Unable to load recipes</h2>";
    }
}

function displayRecipes(recipes) {
    let html = "";

    if (recipes.length === 0) {
        html = `
        <div class="empty-favorites">

            <h2>
                No Recipes Found
            </h2>

        </div>
        `;

        document.getElementById(
            "results"
        ).innerHTML = html;

        return;
    }

    recipes.forEach(recipe => {
        html += `
        <div class="recipe-card">

            <img
                src="${recipe.imageUrl}"
                alt="${recipe.recipeName}">

            <h3>
                ${recipe.recipeName}
            </h3>

            <p>
                ${recipe.description}
            </p>

            <p>
                Category:
                ${recipe.category ?? ""}
            </p>

            <p>
                Type:
                ${recipe.foodType ?? ""}
            </p>

            <p>
                Time:
                ${recipe.cookingTime}
            </p>

            <button
onclick="addFavorite(${recipe.recipeId})">
❤ Favorite
</button>

<button
onclick="openRecipe(${recipe.recipeId})">
View Details
</button>
        </div>
        `;
    });

    document.getElementById(
        "results"
    ).innerHTML = html;
}

function filterCategory(category) {
    if (category === "All") {
        displayRecipes(
            allRecipes
        );

        return;
    }

    const filtered =
        allRecipes.filter(
            recipe =>
                recipe.category === category
        );

    displayRecipes(
        filtered
    );
}

function filterFoodType(foodType) {
    if (foodType === "All") {
        displayRecipes(
            allRecipes
        );

        return;
    }

    const filtered =
        allRecipes.filter(
            recipe =>
                recipe.foodType === foodType
        );

    displayRecipes(
        filtered
    );
}

function openRecipe(id) {
    window.location.href =
        `recipe-details.html?id=${id}`;
}

async function searchRecipes() {
    const ingredients =
        document
            .getElementById("ingredients")
            .value;

    if (!ingredients) {
        alert(
            "Please enter ingredients"
        );
        return;
    }

    try {
        const response =
            await fetch(
                `/api/RecipeApi/search?ingredients=${ingredients}`
            );

        const recipes =
            await response.json();

        displayRecipes(recipes);
    }
    catch (error) {
        console.error(error);

        alert(
            "Search failed"
        );
    }
}