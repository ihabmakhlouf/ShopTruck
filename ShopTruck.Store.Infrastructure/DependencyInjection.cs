using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopTruck.Store.Infrastructure.Data;

namespace ShopTruck.Store.Infrastructure;

public static class DependencyInjection
    {
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
        services.AddDbContext<AppDbContext>(options =>
         options.UseNpgsql("Host=localhost;Port=5432;Database=shoptruck;Username=postgres;Password=superman")
        );
        return services;
        }
    }

