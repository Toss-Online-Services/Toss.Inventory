using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents an associated product list model
/// </summary>
public partial record AssociatedProductListModel : BasePagedListModel<AssociatedProductModel>
{
}