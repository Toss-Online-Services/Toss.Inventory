using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product review and review type mapping search model
/// </summary>
public partial record ProductReviewReviewTypeMappingSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductReviewId { get; set; }

    public bool IsAnyReviewTypes { get; set; }

    #endregion
}