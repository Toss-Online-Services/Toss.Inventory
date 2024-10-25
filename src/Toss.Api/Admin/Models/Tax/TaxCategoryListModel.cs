using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Tax;

/// <summary>
/// Represents a tax category list model
/// </summary>
public partial record TaxCategoryListModel : BasePagedListModel<TaxCategoryModel>
{
}