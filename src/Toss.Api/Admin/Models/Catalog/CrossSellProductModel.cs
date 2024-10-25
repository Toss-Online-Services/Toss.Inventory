using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a cross-sell product model
/// </summary>
public partial record CrossSellProductModel : BaseNopEntityModel
{
    #region Properties

    public int ProductId2 { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.CrossSells.Fields.Product")]
    public string Product2Name { get; set; }

    #endregion
}