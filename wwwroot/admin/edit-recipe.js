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
            `/api/Admin/recipes/${recipeId}`
        );

    const recipe =
        await response.json();

    document.getElementById(
        "recipeName"
    ).value =
        recipe.recipeName;

    document.getElementById(
        "description"
    ).value =
        recipe.description;

    document.getElementById(
        "cookingTime"
    ).value =
        recipe.cookingTime;

    document.getElementById(
        "imageUrl"
    ).value =
        recipe.imageUrl;

    document.getElementById(
        "ingredients"
    ).value =
        recipe.ingredientsText;

    document.getElementById(
        "instructions"
    ).value =
        recipe.instructions;
}

async function updateRecipe()
{
    const recipe =
    {
        recipeName:
            document.getElementById(
                "recipeName"
            ).value,

        description:
            document.getElementById(
                "description"
            ).value,

        cookingTime:
            document.getElementById(
                "cookingTime"
            ).value,

        imageUrl:
            document.getElementById(
                "imageUrl"
            ).value,

        ingredientsText:
            document.getElementById(
                "ingredients"
            ).value,

        instructions:
            document.getElementById(
                "instructions"
            ).value
    };

    const response =
        await fetch(
            `/api/Admin/updaterecipe/${recipeId}`,
            {
                method:"PUT",

                headers:
                {
                    "Content-Type":
                    "application/json"
                },

                body:
                JSON.stringify(recipe)
            });

    if(response.ok)
    {
        alert(
            "Recipe Updated Successfully"
        );

        location.href =
            "manage-recipes.html";
    }
}