using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopTruck.Store.Domain.Interfaces;
using ShopTruck.Store.Infrastructure.Data;
using ShopTruck.Store.Infrastructure.Repositories;

namespace ShopTruck.Store.Infrastructure;

public static class DependencyInjection
    {
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
        services.AddDbContext<AppDbContext>(options =>
         options.UseNpgsql("Host=localhost;Port=5432;Database=shopTruck;Username=postgres;Password=superman")

        );
        services.AddScoped<IStoreRepository, StoreRepository>();
        return services;
        }
    }

