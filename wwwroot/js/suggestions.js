const recipeSuggestions =
[
    "Chicken Biryani",
    "Chicken Curry",
    "Chicken Burger",
    "Chicken Noodles",
    "Chicken Fried Rice",
    "Egg Curry",
    "Egg Fried Rice",
    "Fish Curry",
    "Fish Fry",
    "Omelette",
    "Pasta",
    "Pizza",
    "Burger",
    "Coffee",
    "Milk Shake"
];

document
.getElementById("ingredients")
.addEventListener("input", function()
{
    const value =
        this.value.toLowerCase();

    const suggestionsBox =
        document.getElementById(
            "suggestions"
        );

    suggestionsBox.innerHTML = "";

    if(value.length < 2)
        return;

    const matches =
        recipeSuggestions.filter(
            recipe =>
            recipe.toLowerCase()
            .includes(value)
        );

    matches.forEach(item =>
    {
        const div =
            document.createElement("div");

        div.classList.add(
            "suggestion-item"
        );

        div.innerText = item;

        div.onclick = () =>
        {
            document
            .getElementById(
                "ingredients"
            )
            .value = item;

            suggestionsBox
            .innerHTML = "";
        };

        suggestionsBox
            .appendChild(div);
    });
});