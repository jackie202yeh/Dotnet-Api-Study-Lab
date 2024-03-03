using Microsoft.Extensions.DependencyInjection;
using Repository.Implements;
using Repository.Interfaces;

namespace Repository.DependencyInjection;

public static class RepositoryServiceCollectionExtensions
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}