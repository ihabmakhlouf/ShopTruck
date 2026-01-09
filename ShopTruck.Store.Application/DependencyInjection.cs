using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopTruck.Store.Application.Common;

namespace ShopTruck.Store.Application;

public static class DependencyInjection
    {
    public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        return services;
        }
    }

