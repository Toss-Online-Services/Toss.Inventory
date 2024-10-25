using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Shipping;

/// <summary>
/// Represents a pickup point provider list model
/// </summary>
public partial record PickupPointProviderListModel : BasePagedListModel<PickupPointProviderModel>
{
}