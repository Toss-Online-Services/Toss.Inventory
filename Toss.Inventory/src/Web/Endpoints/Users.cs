using Toss.Inventory.Api.Infrastructure;
using Toss.Inventory.Infrastructure.Identity;

namespace Toss.Inventory.Api.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
