using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a category product list model
/// </summary>
public partial record CategoryProductListModel : BasePagedListModel<CategoryProductModel>
{
}