using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount product search model
/// </summary>
public partial record DiscountProductSearchModel : BaseSearchModel
{
    #region Properties

    public int DiscountId { get; set; }

    #endregion
}