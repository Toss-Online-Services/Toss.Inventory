using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product list model
/// </summary>
public partial record ProductListModel : BasePagedListModel<ProductModel>
{
}