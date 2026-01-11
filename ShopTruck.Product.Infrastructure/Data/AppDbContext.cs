using Microsoft.EntityFrameworkCore;
using ShopTruck.Product.Domain.Entities;


public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );
        }
    }