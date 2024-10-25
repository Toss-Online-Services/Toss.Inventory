using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Shipping;

/// <summary>
/// Represents a warehouse search model
/// </summary>
public partial record WarehouseSearchModel : BaseSearchModel
{
    [NopResourceDisplayName("Admin.Orders.Shipments.List.Warehouse.SearchName")]
    public string SearchName { get; set; }
}