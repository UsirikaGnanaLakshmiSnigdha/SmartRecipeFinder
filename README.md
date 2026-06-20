# Smart Recipe Finder 🍲

## Overview

Smart Recipe Finder is a full-stack web application developed using ASP.NET Core, Entity Framework Core, MySQL, HTML, CSS, and JavaScript.

The application helps users discover recipes based on available ingredients, view recipe details, manage favorite recipes, and explore recipes by category. It also provides an Admin Dashboard for managing recipes, images, and application data.

The project demonstrates a complete Full Stack .NET Architecture including:

* Frontend Development
* RESTful Web APIs
* Authentication & Authorization
* Database Management
* Repository Pattern
* Service Layer Architecture
* Entity Framework Core
* MySQL Integration
* JWT Authentication
* BCrypt Password Hashing

---

# Project Objectives

The main objective of Smart Recipe Finder is to help users:

* Search recipes using ingredients
* View detailed cooking instructions
* Explore recipes by category
* Save favorite recipes
* Manage personal profile
* Access recipes through a responsive web interface

Administrators can:

* Add recipes
* Edit recipes
* Delete recipes
* Upload recipe images
* View dashboard statistics
* Manage application content

---

# Technologies Used

## Frontend

* HTML5
* CSS3
* JavaScript (ES6)

## Backend

* ASP.NET Core Web API
* C#

## Database

* MySQL

## ORM

* Entity Framework Core

## Security

* JWT Authentication
* BCrypt Password Hashing

## Development Tools

* Visual Studio 2022
* Visual Studio Code
* MySQL Workbench
* Swagger UI

---

# System Architecture

Frontend
↓
Controllers
↓
Services
↓
Repositories
↓
Entity Framework Core
↓
MySQL Database

---

# Project Structure

SmartRecipeFinder

├── Controllers

│ ├── AuthController.cs

│ ├── AdminController.cs

│ ├── FavoriteController.cs

│ └── RecipeController.cs

│

├── Data

│ ├── ApplicationDbContext.cs

│ └── DbSeeder.cs

│

├── Models

│ ├── Recipe.cs

│ ├── Ingredient.cs

│ ├── RecipeIngredient.cs

│ ├── User.cs

│ ├── Favorite.cs

│ ├── LoginRequest.cs

│ └── RegisterRequest.cs

│

├── Repository

│ ├── IRecipeRepository.cs

│ ├── RecipeRepository.cs

│ ├── IUserRepository.cs

│ └── UserRepository.cs

│

├── Services

│ ├── IRecipeService.cs

│ ├── RecipeService.cs

│ ├── IUserService.cs

│ └── UserService.cs

│

├── wwwroot

│ ├── css

│ │ └── style.css

│ │

│ ├── js

│ │ ├── login.js

│ │ ├── register.js

│ │ ├── recipes.js

│ │ ├── favorites.js

│ │ ├── profile.js

│ │ ├── admin-auth.js

│ │ ├── api.js

│ │ └── auth.js

│ │

│ ├── images

│ │ └── Recipe Images

│ │

│ ├── index.html

│ ├── recipes.html

│ ├── recipe-details.html

│ ├── login.html

│ ├── register.html

│ ├── favorites.html

│ ├── profile.html

│ │

│ └── admin

│ ├── dashboard.html

│ ├── dashboard.js

│ ├── add-recipe.html

│ ├── add-recipe.js

│ ├── manage-recipes.html

│ ├── manage-recipes.js

│ ├── edit-recipe.html

│ └── edit-recipe.js

│

├── appsettings.json

├── Program.cs

└── README.md

---

# Database Design

## Users Table

| Column       | Type    |
| ------------ | ------- |
| UserId       | INT     |
| FullName     | VARCHAR |
| Email        | VARCHAR |
| PasswordHash | VARCHAR |
| Role         | VARCHAR |

---

## Recipes Table

| Column          | Type    |
| --------------- | ------- |
| RecipeId        | INT     |
| RecipeName      | VARCHAR |
| Description     | TEXT    |
| CookingTime     | VARCHAR |
| ImageUrl        | VARCHAR |
| IngredientsText | TEXT    |
| Instructions    | TEXT    |
| Category        | VARCHAR |
| FoodType        | VARCHAR |

---

## Favorites Table

| Column     | Type |
| ---------- | ---- |
| FavoriteId | INT  |
| UserId     | INT  |
| RecipeId   | INT  |

---

# Features

## User Features

### User Registration

* Create new account
* Email validation
* BCrypt password hashing

### User Login

* Secure login
* JWT token generation
* Session management

### Recipe Search

* Search by ingredients
* Dynamic recipe matching

### Recipe Categories

* Breakfast
* Lunch
* Dinner
* Snacks
* Drinks

### Food Type Filters

* Vegetarian
* Non-Vegetarian

### Recipe Details

* Recipe image
* Cooking time
* Ingredients
* Instructions

### Favorite Recipes

* Add favorites
* Remove favorites
* View saved recipes

### Profile Management

* View profile information
* View role
* Logout functionality

---

## Admin Features

### Admin Login

* Role-based access

### Dashboard

Displays:

* Total Recipes
* Total Users
* Total Favorites

### Recipe Management

* Add Recipe
* Edit Recipe
* Delete Recipe
* View Recipes

### Image Upload

* Upload images
* Store images in wwwroot/images
* Automatic image URL generation

---

# Security Features

## BCrypt Password Hashing

Passwords are never stored in plain text.

Example:

Plain Password:

123456

Stored Value:

$2a$11$hJsd8923jsd82jKJ...

---

## JWT Authentication

After successful login:

1. JWT Token generated
2. Token stored in browser
3. Protected API access

---

## Role Authorization

Admin-only routes protected using:

[Authorize(Roles = "Admin")]

---

# API Endpoints

## Authentication

POST

/api/Auth/register

POST

/api/Auth/login

---

## Recipes

GET

/api/Recipe/search

GET

/api/Recipe/{id}

---

## Favorites

POST

/api/Favorite/add

GET

/api/Favorite/{userId}

DELETE

/api/Favorite/remove

---

## Admin

GET

/api/Admin/dashboard

GET

/api/Admin/recipes

GET

/api/Admin/recipes/{id}

POST

/api/Admin/addrecipe

PUT

/api/Admin/updaterecipe/{id}

DELETE

/api/Admin/deleterecipe/{id}

POST

/api/Admin/upload-image

---

# Installation Guide

## Step 1

Clone Repository

git clone <repository-url>

---

## Step 2

Install Dependencies

dotnet restore

---

## Step 3

Configure Database

Update appsettings.json

ConnectionStrings:

server=localhost;
database=RecipeDB;
uid=root;
pwd=yourpassword;

---

## Step 4

Run Migrations

Update Database

---

## Step 5

Run Application

dotnet run

---

## Step 6

Open Browser

http://localhost:5035

Swagger:

http://localhost:5035/swagger

---

# Sample Admin Credentials

Email:

[admin@recipe.com](mailto:admin@recipe.com)

Password:

admin123

---

# Future Enhancements

* AI Recipe Recommendations
* Nutrition Analysis
* Recipe Ratings
* Recipe Comments
* Email Notifications
* Mobile Application
* Cloud Deployment
* Social Login
* Recipe Sharing
* Meal Planner

---

# Learning Outcomes

Through this project the following concepts were implemented:

* ASP.NET Core Web API
* Entity Framework Core
* Repository Pattern
* Service Layer Pattern
* MySQL Integration
* Authentication & Authorization
* JWT Security
* BCrypt Hashing
* CRUD Operations
* Frontend Development
* REST API Development
* Full Stack Application Development

---

# Conclusion

Smart Recipe Finder is a complete Full Stack .NET web application that enables users to discover recipes, manage favorites, and explore cooking ideas while allowing administrators to manage recipes efficiently.

The project demonstrates modern web development practices including layered architecture, secure authentication, database integration, responsive UI design, and RESTful API development.
