using System.Data.Common;

<<<<<<< HEAD
namespace Toss.Inventory.Application.FunctionalTests;
=======
namespace Toss.Inventory.Catalog.Application.FunctionalTests;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    Task ResetAsync();

    Task DisposeAsync();
}
