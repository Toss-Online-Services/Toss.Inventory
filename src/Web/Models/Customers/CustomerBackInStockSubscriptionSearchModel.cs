namespace Web.Models.Customers;

/// <summary>
/// Represents a customer back in stock subscriptions search model
/// </summary>
public partial record CustomerBackInStockSubscriptionSearchModel : BaseSearchModel
{
    #region Properties

    public int CustomerId { get; set; }

    #endregion
}