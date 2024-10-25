using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a category model to add to the discount
/// </summary>
public partial record AddCategoryToDiscountModel : BaseNopModel
{
    #region Ctor

    public AddCategoryToDiscountModel()
    {
        SelectedCategoryIds = new List<int>();
    }
    #endregion

    #region Properties

    public int DiscountId { get; set; }

    public IList<int> SelectedCategoryIds { get; set; }

    #endregion
}