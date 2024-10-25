using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a reward points search model
/// </summary>
public partial record CustomerRewardPointsSearchModel : BaseSearchModel
{
    #region Properties

    public int CustomerId { get; set; }

    #endregion
}