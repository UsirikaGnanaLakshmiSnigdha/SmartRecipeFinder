function showPopup(
    recipeName,
    description,
    cookingTime,
    ingredients,
    instructions,
    imageUrl,
    matchPercentage
)
{
    const recipeDetails =
        document.getElementById("recipeDetails");

    recipeDetails.innerHTML = `

        <img
            src="${imageUrl}"
            class="popup-image"
            alt="${recipeName}">

        <h2>${recipeName}</h2>

        <p>
            <strong>Description:</strong>
            ${description}
        </p>

        <p>
            <strong>Cooking Time:</strong>
            ${cookingTime}
        </p>

        <p>
            <strong>Match Percentage:</strong>
            ${Math.round(matchPercentage)}%
        </p>

        <p>
            <strong>Ingredients:</strong>
            ${ingredients}
        </p>

        <p>
            <strong>Instructions:</strong>
            ${instructions}
        </p>

    `;

    document.getElementById("recipeModal")
        .style.display = "block";
}

function closePopup()
{
    document.getElementById("recipeModal")
        .style.display = "none";
}

window.onclick = function(event)
{
    const modal =
        document.getElementById("recipeModal");

    if(event.target === modal)
    {
        modal.style.display = "none";
    }
}