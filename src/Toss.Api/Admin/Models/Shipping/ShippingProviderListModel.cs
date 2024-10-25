using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Shipping;

/// <summary>
/// Represents a shipping provider list model
/// </summary>
public partial record ShippingProviderListModel : BasePagedListModel<ShippingProviderModel>
{
}