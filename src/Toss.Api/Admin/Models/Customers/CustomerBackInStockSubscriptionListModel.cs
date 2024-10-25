using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer back in stock subscriptions list model
/// </summary>
public partial record CustomerBackInStockSubscriptionListModel : BasePagedListModel<CustomerBackInStockSubscriptionModel>
{
}