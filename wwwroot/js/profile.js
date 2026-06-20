const user =
    JSON.parse(
        localStorage.getItem(
            "currentUser"
        ));

if(!user)
{
    location.href =
        "login.html";
}
else
{
    document.getElementById(
        "fullName"
    ).innerText =
        user.fullName;

    document.getElementById(
        "email"
    ).innerText =
        "Email: " + user.email;

    document.getElementById(
        "role"
    ).innerText =
        "Role: " + user.role;
}

