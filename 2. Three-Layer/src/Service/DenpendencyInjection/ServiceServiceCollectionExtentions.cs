using Microsoft.Extensions.DependencyInjection;
using Service.Implements;
using Service.Interfaces;

namespace Service.DenpendencyInjection;

public static class ServiceServiceCollectionExtentions
{
    public static void AddService(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();
    }
}