using Microsoft.EntityFrameworkCore;
using SmartRecipeFinder.Data;
using SmartRecipeFinder.Repository;
using SmartRecipeFinder.Services;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ======================================
// SERVICES
// ======================================

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });

// ======================================
// JWT AUTHENTICATION
// ======================================

builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!))
            };
    });

// ======================================
// SWAGGER
// ======================================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// ======================================
// CORS
// ======================================

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// ======================================
// DATABASE
// ======================================

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseMySql(
            builder.Configuration
                .GetConnectionString(
                    "DefaultConnection"),
            ServerVersion.AutoDetect(
                builder.Configuration
                    .GetConnectionString(
                        "DefaultConnection")));
    });

// ======================================
// APP
// ======================================

var app = builder.Build();

// ======================================
// DATABASE SEED
// ======================================

using (var scope =
       app.Services.CreateScope())
{
    var context =
        scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

    DbSeeder.Seed(context);
}

// ======================================
// MIDDLEWARE
// ======================================

app.UseSwagger();

app.UseSwaggerUI();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

// ======================================
// CONTROLLERS
// ======================================

app.MapControllers();

app.Run();