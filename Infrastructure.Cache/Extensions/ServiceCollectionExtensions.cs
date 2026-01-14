using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopTruck.Infrastructure.Cache.Abstractions;
using ShopTruck.Infrastructure.Cache.Redis;

namespace ShopTruck.Infrastructure.Cache.Extensions;

public static class ServiceCollectionExtensions
    {
    public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });

        services.AddScoped<ICacheService, RedisCacheService>();
        return services;
        }
    }
