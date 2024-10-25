using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount category search model
/// </summary>
public partial record DiscountCategorySearchModel : BaseSearchModel
{
    #region Properties

    public int DiscountId { get; set; }

    #endregion
}