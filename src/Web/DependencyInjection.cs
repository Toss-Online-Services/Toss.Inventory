using Azure.Identity;
<<<<<<< HEAD
using Toss.Inventory.Application.Common.Interfaces;
using Toss.Inventory.Infrastructure.Data;
using Toss.Inventory.Web.Services;
=======
using Toss.Inventory.Catalog.Web.Services;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1
using Microsoft.AspNetCore.Mvc;

using NSwag;
using NSwag.Generation.Processors.Security;
<<<<<<< HEAD

namespace Microsoft.Extensions.DependencyInjection;
=======
using Application.Common.Interfaces;
using Infrastructure.Data;
using Application.Common.Behaviours;
using Domain.Repositories;
using FluentValidation;
using System.Reflection;
using Infrastructure.Data.Repositories;

namespace Toss.Inventory.Catalog.Web;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddRazorPages();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument((configure, sp) =>
        {
<<<<<<< HEAD
            configure.Title = "Toss.Inventory API";
=======
            configure.Title = "Toss.Inventory.Catalog API";
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

            // Add JWT
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });

<<<<<<< HEAD
=======
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });

        services.AddScoped<IProductRepository, ProductRepository>();

>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1
        return services;
    }

    public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services, ConfigurationManager configuration)
    {
        var keyVaultUri = configuration["KeyVaultUri"];
        if (!string.IsNullOrWhiteSpace(keyVaultUri))
        {
            configuration.AddAzureKeyVault(
                new Uri(keyVaultUri),
                new DefaultAzureCredential());
        }

        return services;
    }
}
