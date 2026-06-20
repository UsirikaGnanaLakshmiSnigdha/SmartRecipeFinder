const currentUser =
    JSON.parse(
        localStorage.getItem(
            "currentUser"
        ));

if(
    !currentUser
)
{
    alert(
        "Please Login"
    );

    location.href =
        "../login.html";
}
else if(
    currentUser.role !==
    "Admin"
)
{
    alert(
        "Access Denied"
    );

    location.href =
        "../index.html";
}