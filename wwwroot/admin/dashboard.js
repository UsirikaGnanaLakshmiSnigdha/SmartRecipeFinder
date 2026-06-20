loadDashboard();

async function loadDashboard()
{
    const response =
        await fetch(
            "/api/Admin/dashboard"
        );

    const data =
        await response.json();

    document.getElementById(
        "totalRecipes"
    ).innerText =
        data.totalRecipes;

    document.getElementById(
        "totalUsers"
    ).innerText =
        data.totalUsers;

    document.getElementById(
        "totalFavorites"
    ).innerText =
        data.totalFavorites;
}