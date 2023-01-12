using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ResturantAPI.Models;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DbContext> options) : base(options)
    { }

    public DbSet<Resturaunt> Resturants { get; set; } = null;
    public DbSet<Cuisine> Cuisines { get; set; } = null;
    public DbSet<Grade> Grades { get; set; } = null;
    public DbSet<Menu> Menus { get; set; } = null;
    public DbSet<RestConnCuisine> RestConnCuisines { get; set; } = null;
    public DbSet<Score> Scores { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resturaunt>(entity =>
            { entity.ToTable("Resturant", "dbo");  } );

        modelBuilder.Entity<Cuisine>(entity =>
            { entity.ToTable("Cuisine", "dbo"); } );

        modelBuilder.Entity<Grade>(entity =>
            { entity.ToTable("Grade", "dbo"); } );

        modelBuilder.Entity<Menu>(entity =>
            { entity.ToTable("Menu", "dbo"); } );

        modelBuilder.Entity<RestConnCuisine>(entity =>
            { entity.ToTable("RestConnCuisine", "dbo"); } );

        modelBuilder.Entity<Score>(entity =>
            { entity.ToTable("Score", "dbo"); } );
    }
}
