async function registerUser()
{
    const fullName =
        document.getElementById(
            "fullName"
        ).value;

    const email =
        document.getElementById(
            "email"
        ).value;

    const password =
        document.getElementById(
            "password"
        ).value;

    await fetch(
        "/api/Auth/register",
        {
            method:"POST",

            headers:
            {
                "Content-Type":
                "application/json"
            },

            body:JSON.stringify({
                fullName,
                email,
                password,
                role:"User"
            })
        });

    alert(
        "Registration Successful"
    );

    location.href =
    "login.html";
}