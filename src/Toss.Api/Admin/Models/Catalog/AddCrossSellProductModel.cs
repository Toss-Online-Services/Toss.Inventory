using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a cross-sell product model to add to the product
/// </summary>
public partial record AddCrossSellProductModel : BaseNopModel
{
    #region Ctor

    public AddCrossSellProductModel()
    {
        SelectedProductIds = new List<int>();
    }
    #endregion

    #region Properties

    public int ProductId { get; set; }

    public IList<int> SelectedProductIds { get; set; }

    #endregion
}