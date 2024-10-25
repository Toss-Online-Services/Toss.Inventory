using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a category list model
/// </summary>
public partial record CategoryListModel : BasePagedListModel<CategoryModel>
{
}