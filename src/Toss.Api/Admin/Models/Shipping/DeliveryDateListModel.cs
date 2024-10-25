using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Shipping;

/// <summary>
/// Represents a delivery date list model
/// </summary>
public partial record DeliveryDateListModel : BasePagedListModel<DeliveryDateModel>
{
}