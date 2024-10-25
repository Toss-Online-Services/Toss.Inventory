using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a category list model to add to the discount
/// </summary>
public partial record AddCategoryToDiscountListModel : BasePagedListModel<CategoryModel>
{
}