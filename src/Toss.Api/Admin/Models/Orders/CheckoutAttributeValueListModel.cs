using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a checkout attribute value list model
/// </summary>
public partial record CheckoutAttributeValueListModel : BasePagedListModel<CheckoutAttributeValueModel>
{
}