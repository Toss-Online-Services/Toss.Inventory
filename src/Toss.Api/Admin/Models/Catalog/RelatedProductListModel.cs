using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a related product list model
/// </summary>
public partial record RelatedProductListModel : BasePagedListModel<RelatedProductModel>
{
}