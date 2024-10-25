using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer activity log search model
/// </summary>
public partial record CustomerActivityLogSearchModel : BaseSearchModel
{
    #region Properties

    public int CustomerId { get; set; }

    #endregion
}