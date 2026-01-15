using Microsoft.EntityFrameworkCore;
using ShopTruck.Store.Domain.Entities;
namespace ShopTruck.Store.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
    public DbSet<Domain.Entities.Store> Stores { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );
        }
    }