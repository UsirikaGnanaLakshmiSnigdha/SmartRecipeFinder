using Microsoft.EntityFrameworkCore;
using SmartRecipeFinder.Models;

namespace SmartRecipeFinder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(r => r.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(r => r.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(i => i.IngredientId);
        }
    }
}