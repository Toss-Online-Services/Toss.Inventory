using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product review list model
/// </summary>
public partial record ProductReviewListModel : BasePagedListModel<ProductReviewModel>
{
}