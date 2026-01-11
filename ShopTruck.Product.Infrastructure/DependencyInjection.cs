using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopTruck.Product.Domain.Interfaces;
using ShopTruck.Product.Infrastructure.Repositories;


namespace ShopTruck.Store.Infrastructure;

public static class DependencyInjection
    {
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
        services.AddDbContext<AppDbContext>(options =>
         options.UseNpgsql("Host=localhost;Port=5432;Database=shopTruck;Username=postgres;Password=superman")

        );
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
        }
    }