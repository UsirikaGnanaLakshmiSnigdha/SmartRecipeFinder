async function addFavorite(recipeId) {
    const user =
        JSON.parse(
            localStorage.getItem(
                "currentUser"
            ));

    if (!user) {
        alert("Please Login First");

        location.href =
            "login.html";

        return;
    }

    const response =
        await fetch(
            "/api/Favorite/add",
            {
                method: "POST",

                headers:
                {
                    "Content-Type":
                        "application/json"
                },

                body:
                    JSON.stringify({
                        userId: user.userId,
                        recipeId: recipeId
                    })
            });

    if (response.ok) {
        alert(
            "Added To Favorites"
        );
    }
    else {
        alert(
            "Already Added"
        );
    }
}

document
.getElementById(
    "favoriteRecipes"
)
.innerHTML = "";

async function loadFavorites() {
    const user =
        JSON.parse(
            localStorage.getItem(
                "currentUser"
            ));

    if (!user) {
        return;
    }

    const response =
        await fetch(
            `/api/Favorite/${user.userId}`
        );

    const favorites =
        await response.json();

    let html = "";

    for (const favorite of favorites) {
        const recipeResponse =
            await fetch(
                `/api/Admin/recipes/${favorite.recipeId}`
            );

        const recipe =
            await recipeResponse.json();

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
                ${recipe.cookingTime}
            </p>

            <button
onclick="openRecipe(${recipe.recipeId})">
View Details
</button>

<button
onclick="
removeFavorite(
${favorite.recipeId}
)">
🗑 Remove
</button>

        </div>
        `;
    }

    document.getElementById(
        "favoriteRecipes"
    ).innerHTML = html;
}

function openRecipe(id) {
    location.href =
        `recipe-details.html?id=${id}`;
}

loadFavorites();

async function removeFavorite(
    recipeId)
{
    const user =
        JSON.parse(
            localStorage.getItem(
                "currentUser"
            ));

    if(!user)
        return;

    const response =
        await fetch(
            `/api/Favorite/remove?userId=${user.userId}&recipeId=${recipeId}`,
            {
                method:"DELETE"
            });

    if(response.ok)
    {
        alert(
            "Removed Successfully"
        );

        loadFavorites();
    }
}