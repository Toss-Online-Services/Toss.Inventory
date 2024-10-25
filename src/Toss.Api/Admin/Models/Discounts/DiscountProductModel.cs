using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount product model
/// </summary>
public partial record DiscountProductModel : BaseNopEntityModel
{
    #region Properties

    public int ProductId { get; set; }

    public string ProductName { get; set; }

    #endregion
}