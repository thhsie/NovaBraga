using Domain.Pricing;
using Domain.Products;
using Domain.SharedKernel;
using Infrastructure.Common;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, MachineDateTime>();
        
        services
            .AddScoped<NovaBragaDbContext>()
            .AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddRepositories();
        
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IProductWriteOnlyRepository, ProductWriteOnlyRepository>()
            .AddScoped<IProductReadOnlyRepository, ProductReadOnlyRepository>()
            .AddScoped<IPricingWriteOnlyRepository, PricingWriteOnlyRepository>()
            .AddScoped<IPricingReadOnlyRepository, PricingReadOnlyRepository>();

        return services;
    }
}