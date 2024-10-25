using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a category search model to add to the discount
/// </summary>
public partial record AddCategoryToDiscountSearchModel : BaseSearchModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Catalog.Categories.List.SearchCategoryName")]
    public string SearchCategoryName { get; set; }

    #endregion
}