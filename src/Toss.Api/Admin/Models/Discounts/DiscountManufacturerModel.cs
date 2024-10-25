using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount manufacturer model
/// </summary>
public partial record DiscountManufacturerModel : BaseNopEntityModel
{
    #region Properties

    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; }

    #endregion
}