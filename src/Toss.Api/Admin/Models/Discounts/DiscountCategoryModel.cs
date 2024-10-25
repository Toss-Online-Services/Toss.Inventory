using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount category model
/// </summary>
public partial record DiscountCategoryModel : BaseNopEntityModel
{
    #region Properties

    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    #endregion
}