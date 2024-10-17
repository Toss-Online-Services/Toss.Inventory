using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;
using FluentMigrator.Runner.Conventions;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        /// 
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;

            // Pooling is disabled because of the following error:
            // Unhandled exception. System.InvalidOperationException:
            // The DbContext of type 'OrderingContext' cannot be pooled because it does not have a public constructor accepting a single parameter of type DbContextOptions or has more than one constructor.
            services.AddDbContext<InventoryContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("inventorydb"));
            });
           // builder.EnrichNpgsqlDbContext<InventoryContext>();

            // Get the current assembly containing migrations
            var currentAssembly = typeof(InventoryContext).Assembly;

            // Add FluentMigrator services and configure the runner
            services
                .AddFluentMigratorCore()   
                .ConfigureRunner(rb =>
                    rb.WithVersionTable(new MigrationVersionInfo())
                      .AddPostgres()
                      .ScanIn(currentAssembly).For.Migrations());

            // Add version loader lazily
            services.AddTransient(p => new Lazy<IVersionLoader>(p.GetRequiredService<IVersionLoader>()));

            // Add repository service
            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
            // REVIEW: This is done for development ease but shouldn't be here in production
            
            // Apply migrations on application startup
            //ApplyMigrations(services);         
        }

        /// <summary>
        /// Apply migrations using FluentMigrator
        /// </summary>
        private static void ApplyMigrations(IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var migrationRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            // Run all the migrations
            migrationRunner.MigrateUp();
        }
    }
}
