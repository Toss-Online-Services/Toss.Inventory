using System.Data.Common;
<<<<<<< HEAD
using Toss.Inventory.Application.Common.Interfaces;
using Toss.Inventory.Infrastructure.Data;
=======
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
<<<<<<< HEAD

namespace Toss.Inventory.Application.FunctionalTests;
=======
using Application.Common.Interfaces;
using Infrastructure.Data;

namespace Toss.Inventory.Catalog.Application.FunctionalTests;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

using static Testing;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly DbConnection _connection;

    public CustomWebApplicationFactory(DbConnection connection)
    {
        _connection = connection;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services
                .RemoveAll<IUser>()
                .AddTransient(provider => Mock.Of<IUser>(s => s.Id == GetUserId()));

            services
                .RemoveAll<DbContextOptions<ApplicationDbContext>>()
                .AddDbContext<ApplicationDbContext>((sp, options) =>
                {
                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                    options.UseSqlServer(_connection);
                });
        });
    }
}
