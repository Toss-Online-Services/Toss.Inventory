using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a checkout attribute list model
/// </summary>
public partial record CheckoutAttributeListModel : BasePagedListModel<CheckoutAttributeModel>
{
}