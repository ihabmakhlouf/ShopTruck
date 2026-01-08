using Microsoft.EntityFrameworkCore;
namespace ShopTruck.Store.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
    public DbSet<Domain.Entities.Store> Stores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );
        }
    }