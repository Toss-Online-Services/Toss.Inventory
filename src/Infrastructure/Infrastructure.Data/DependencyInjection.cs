//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Domain.Constants;
//using Infrastructure.Identity;
//using Infrastructure.Data.Interceptors;
//using Application.Common.Interfaces;

//namespace Infrastructure.Data;

//public static class DependencyInjection
//{
//    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
//    {
//        var connectionString = configuration.GetConnectionString("DefaultConnection");

//        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

//        //services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
//        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

//        services.AddDbContext<ApplicationDbContext>((sp, options) =>
//        {
//            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

//            options.UseSqlServer(connectionString);
//        });

//        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

//        services.AddScoped<ApplicationDbContextInitialiser>();

//        services.AddAuthentication()
//            .AddBearerToken(IdentityConstants.BearerScheme);

//        services.AddAuthorizationBuilder();

//        services
//            .AddIdentityCore<ApplicationUser>()
//            .AddRoles<IdentityRole>()
//            .AddEntityFrameworkStores<ApplicationDbContext>()
//            .AddApiEndpoints();

//        services.AddSingleton(TimeProvider.System);
//        services.AddTransient<IIdentityService, IdentityService>();

//        services.AddAuthorization(options =>
//            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

//        return services;
//    }
//}
