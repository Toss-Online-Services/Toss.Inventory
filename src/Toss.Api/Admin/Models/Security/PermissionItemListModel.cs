using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Security;

/// <summary>
/// Represents a permission item list model
/// </summary>
public partial record PermissionItemListModel : BasePagedListModel<PermissionItemModel>
{
}