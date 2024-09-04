//using System.Data.Common;
//using Microsoft.AspNetCore.Mvc.Testing;

//namespace Toss.Inventory.Application.FunctionalTests;
//public class CustomWebApplicationFactory : WebApplicationFactory<Program>
//{
//    private readonly DbConnection _connection;

//    public CustomWebApplicationFactory(DbConnection connection)
//    {
//        _connection = connection;
//    }

//    //protected override void ConfigureWebHost(IWebHostBuilder builder)
//    //{
//    //    builder.ConfigureTestServices(services =>
//    //    {
//    //        services
//    //            .RemoveAll<IUser>()
//    //            .AddTransient(provider => Mock.Of<IUser>(s => s.Id == GetUserId()));

//    //        services
//    //            .RemoveAll<DbContextOptions<ApplicationDbContext>>()
//    //            .AddDbContext<ApplicationDbContext>((sp, options) =>
//    //            {
//    //                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
//    //                options.UseSqlServer(_connection);
//    //            });
//    //    });
//    //}
//}
