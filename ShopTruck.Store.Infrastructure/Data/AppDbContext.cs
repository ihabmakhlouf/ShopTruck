using Microsoft.EntityFrameworkCore;

namespace ShopTruck.Store.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
    public DbSet<Store> Stores { get; set; }
    }

