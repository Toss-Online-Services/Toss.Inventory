using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a shipment list model
/// </summary>
public partial record ShipmentListModel : BasePagedListModel<ShipmentModel>
{
}