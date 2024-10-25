using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Shipping;

/// <summary>
/// Represents a shipping method list model
/// </summary>
public partial record ShippingMethodListModel : BasePagedListModel<ShippingMethodModel>
{
}