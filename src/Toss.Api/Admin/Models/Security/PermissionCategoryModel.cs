using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Security;

public partial record PermissionCategoryModel : BaseNopModel
{
    public string Name { get; set; }

    public string Text { get; set; }
}