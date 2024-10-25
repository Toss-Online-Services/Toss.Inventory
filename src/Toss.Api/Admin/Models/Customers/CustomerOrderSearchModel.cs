using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer orders search model
/// </summary>
public partial record CustomerOrderSearchModel : BaseSearchModel
{
    #region Properties

    public int CustomerId { get; set; }

    #endregion
}