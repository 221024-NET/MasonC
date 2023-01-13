using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ResturantAPI.Models;

public class RestContext : DbContext
{
    public RestContext(DbContextOptions<RestContext> options) : base(options)
    { }

    public DbSet<Resturaunt> Resturants { get; set; } = null!;
    public DbSet<Cuisine> Cuisines { get; set; } = null!;
    public DbSet<Grade> Grades { get; set; } = null!;
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<RestConnCuisine> RestConnCuisines { get; set; } = null!;
    public DbSet<Score> Scores { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resturaunt>(entity =>
            { entity.ToTable("Restaurant");  } );

        modelBuilder.Entity<Cuisine>(entity =>
            { entity.ToTable("Cuisine"); } );

        modelBuilder.Entity<Grade>(entity =>
            { entity.ToTable("Grade"); } );

        modelBuilder.Entity<Menu>(entity =>
            { entity.ToTable("Menu"); } );

        modelBuilder.Entity<RestConnCuisine>(entity =>
            { entity.ToTable("RestConnCuisine"); } );

        modelBuilder.Entity<Score>(entity =>
            { entity.ToTable("Score"); } );
    }
}
