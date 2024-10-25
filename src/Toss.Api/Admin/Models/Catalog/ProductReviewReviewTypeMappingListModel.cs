using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product review and review type mapping list model
/// </summary>
public partial record ProductReviewReviewTypeMappingListModel : BasePagedListModel<ProductReviewReviewTypeMappingModel>
{
}