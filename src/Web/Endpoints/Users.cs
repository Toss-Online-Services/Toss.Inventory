﻿using Toss.Inventory.Catalog.Infrastructure.Identity;

namespace Toss.Inventory.Catalog.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}