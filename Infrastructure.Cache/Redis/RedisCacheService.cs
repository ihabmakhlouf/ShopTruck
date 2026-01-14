using Microsoft.Extensions.Caching.Distributed;
using ShopTruck.Infrastructure.Cache.Abstractions;
using System.Text.Json;

namespace ShopTruck.Infrastructure.Cache.Redis;

public class RedisCacheService : ICacheService
    {
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache cache)
        {
        _cache = cache;
        }

    public async Task<T?> GetAsync<T>(string key)
        {
        var json = await _cache.GetStringAsync(key);
        return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }

    public async Task SetAsync<T>(string key, T value, TimeSpan ttl)
        {
        await _cache.SetStringAsync(
            key,
            JsonSerializer.Serialize(value),
            new DistributedCacheEntryOptions
                {
                AbsoluteExpirationRelativeToNow = ttl
                });
        }

    public Task RemoveAsync(string key)
        => _cache.RemoveAsync(key);

    public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T?>> factory, TimeSpan ttl)
        {
        var cached = await GetAsync<T>(key);
        if (cached != null)
            return cached;

        var value = await factory();
        if (value != null)
            await SetAsync(key, value, ttl);

        return value;
        }
    }

