using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
  }
