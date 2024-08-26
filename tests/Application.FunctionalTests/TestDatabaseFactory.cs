<<<<<<< HEAD
﻿namespace Toss.Inventory.Application.FunctionalTests;
=======
﻿namespace Toss.Inventory.Catalog.Application.FunctionalTests;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new TestcontainersTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}
