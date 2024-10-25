using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Security;

/// <summary>
/// Represents a permission category list model
/// </summary>
public partial record PermissionCategoryListModel : BasePagedListModel<PermissionCategoryModel>
{
}