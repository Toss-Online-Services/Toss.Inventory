using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer back in stock subscriptions search model
/// </summary>
public partial record CustomerBackInStockSubscriptionSearchModel : BaseSearchModel
{
    #region Properties

    public int CustomerId { get; set; }

    #endregion
}