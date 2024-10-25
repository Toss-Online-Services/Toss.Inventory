using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Shipping;

/// <summary>
/// Represents a warehouse list model
/// </summary>
public partial record WarehouseListModel : BasePagedListModel<WarehouseModel>
{
}