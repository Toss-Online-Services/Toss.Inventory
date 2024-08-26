<<<<<<< HEAD
﻿namespace Toss.Inventory.Application.FunctionalTests;
=======
﻿namespace Toss.Inventory.Catalog.Application.FunctionalTests;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

using static Testing;

[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
