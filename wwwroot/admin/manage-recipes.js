loadRecipes();

async function loadRecipes()
{
    const response =
        await fetch(
            "/api/Admin/recipes"
        );

    const recipes =
        await response.json();

    let html = "";

    recipes.forEach(recipe =>
    {
        html += `
        <tr>

            <td>
                ${recipe.recipeId}
            </td>

            <td>
                ${recipe.recipeName}
            </td>

            <td>
                ${recipe.category}
            </td>

            <td>
                ${recipe.foodType}
            </td>

            <td>

                <button
                onclick="editRecipe(${recipe.recipeId})">
                Edit
                </button>

                <button
                onclick="deleteRecipe(${recipe.recipeId})">
                Delete
                </button>

            </td>

        </tr>
        `;
    });

    document
    .querySelector("#recipeTable tbody")
    .innerHTML = html;
}

function editRecipe(id)
{
    location.href =
        `edit-recipe.html?id=${id}`;
}

async function deleteRecipe(id)
{
    if(
        !confirm(
            "Delete this recipe?"
        )
    )
    {
        return;
    }

    const response =
        await fetch(
            `/api/Admin/deleterecipe/${id}`,
            {
                method:"DELETE"
            });

    if(response.ok)
    {
        alert(
            "Recipe Deleted"
        );

        loadRecipes();
    }
}