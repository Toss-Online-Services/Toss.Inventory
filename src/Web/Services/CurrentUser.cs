using System.Security.Claims;
<<<<<<< HEAD

using Toss.Inventory.Application.Common.Interfaces;

namespace Toss.Inventory.Web.Services;
=======
using Application.Common.Interfaces;

namespace Toss.Inventory.Catalog.Web.Services;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
