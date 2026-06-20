async function loginUser() {
    const email =
        document.getElementById("email").value.trim();

    const password =
        document.getElementById("password").value.trim();

    if (email === "" || password === "") {
        alert(
            "Please enter Email and Password"
        );

        return;
    }

    try {
        const response =
            await fetch(
                "/api/Auth/login",
                {
                    method: "POST",

                    headers:
                    {
                        "Content-Type":
                            "application/json"
                    },

                    body:
                        JSON.stringify({
                            email,
                            password
                        })
                });

        if (!response.ok) {
            alert(
                "Invalid Email or Password"
            );

            return;
        }

        const user =
            await response.json();

        localStorage.setItem(
            "token",
            user.token
        );

        localStorage.setItem(
            "currentUser",
            JSON.stringify({
                userId: user.userId,
                fullName: user.fullName,
                email: user.email,
                role: user.role
            })
        );
        if (user.role === "Admin") {
            window.location.href =
                "admin/dashboard.html";
        }
        else {
            window.location.href =
                "index.html";
        }
    }
    catch (error) {
        console.error(error);

        alert(
            "Unable to connect to server."
        );
    }
}