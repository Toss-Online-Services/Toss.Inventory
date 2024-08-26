using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Entities;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
