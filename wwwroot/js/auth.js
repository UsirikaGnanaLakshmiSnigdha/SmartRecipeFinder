function getCurrentUser()
{
    const user =
        localStorage.getItem(
            "currentUser"
        );

    if(user)
    {
        return JSON.parse(user);
    }

    return null;
}

function logoutUser()
{
    localStorage.removeItem(
        "currentUser"
    );

    alert(
        "Logged Out Successfully"
    );

    window.location.href =
        "../login.html";
}