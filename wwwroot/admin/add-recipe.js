// ================================
// IMAGE PREVIEW
// ================================

document.addEventListener(
    "DOMContentLoaded",
    function ()
    {
        const imageInput =
            document.getElementById(
                "recipeImage"
            );

        if(imageInput)
        {
            imageInput.addEventListener(
                "change",
                function(event)
                {
                    const file =
                        event.target.files[0];

                    if(file)
                    {
                        const reader =
                            new FileReader();

                        reader.onload =
                            function(e)
                            {
                                const preview =
                                    document.getElementById(
                                        "previewImage"
                                    );

                                preview.src =
                                    e.target.result;

                                preview.style.display =
                                    "block";
                            };

                        reader.readAsDataURL(
                            file
                        );
                    }
                });
        }
    });

// ================================
// ADD RECIPE
// ================================

async function addRecipe()
{
    try
    {
        let imageUrl = "";

        const imageFile =
            document.getElementById(
                "recipeImage"
            ).files[0];

        // ========================
        // UPLOAD IMAGE
        // ========================

        if(imageFile)
        {
            const formData =
                new FormData();

            formData.append(
                "file",
                imageFile
            );

            const uploadResponse =
                await fetch(
                    "/api/Admin/upload-image",
                    {
                        method: "POST",
                        body: formData
                    });

            if(!uploadResponse.ok)
            {
                alert(
                    "Image Upload Failed"
                );

                return;
            }

            const uploadResult =
                await uploadResponse.json();

            imageUrl =
                uploadResult.imageUrl;
        }

        // ========================
        // RECIPE OBJECT
        // ========================

        const recipe =
        {
            recipeName:
                document.getElementById(
                    "recipeName"
                ).value.trim(),

            description:
                document.getElementById(
                    "description"
                ).value.trim(),

            cookingTime:
                document.getElementById(
                    "cookingTime"
                ).value.trim(),

            imageUrl:
                imageUrl,

            ingredientsText:
                document.getElementById(
                    "ingredients"
                ).value.trim(),

            instructions:
                document.getElementById(
                    "instructions"
                ).value.trim(),

            category:
                document.getElementById(
                    "category"
                ).value,

            foodType:
                document.getElementById(
                    "foodType"
                ).value
        };

        // ========================
        // VALIDATION
        // ========================

        if(recipe.recipeName === "")
        {
            alert(
                "Recipe Name Required"
            );

            return;
        }

        // ========================
        // SAVE RECIPE
        // ========================

        const response =
            await fetch(
                "/api/Admin/addrecipe",
                {
                    method: "POST",

                    headers:
                    {
                        "Content-Type":
                        "application/json"
                    },

                    body:
                    JSON.stringify(
                        recipe
                    )
                });

        if(response.ok)
        {
            alert(
                "Recipe Added Successfully"
            );

            clearForm();
        }
        else
        {
            alert(
                "Failed To Add Recipe"
            );
        }
    }
    catch(error)
    {
        console.error(error);

        alert(
            "Something went wrong."
        );
    }
}

// ================================
// CLEAR FORM
// ================================

function clearForm()
{
    document.getElementById(
        "recipeName"
    ).value = "";

    document.getElementById(
        "description"
    ).value = "";

    document.getElementById(
        "cookingTime"
    ).value = "";

    document.getElementById(
        "ingredients"
    ).value = "";

    document.getElementById(
        "instructions"
    ).value = "";

    document.getElementById(
        "recipeImage"
    ).value = "";

    document.getElementById(
        "previewImage"
    ).style.display = "none";
}