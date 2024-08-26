<<<<<<< HEAD
﻿using Toss.Inventory.Infrastructure.Identity;

namespace Toss.Inventory.Web.Endpoints;
=======
﻿using Infrastructure.Identity;

namespace Toss.Inventory.Catalog.Web.Endpoints;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
