using Nop.Core.Domain.Catalog;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Factories;

/// <summary>
/// Represents a review type model factory
/// </summary>
public partial interface IReviewTypeModelFactory
{
    /// <summary>
    /// Prepare review type search model
    /// </summary>
    /// <param name="searchModel">Review type search model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the review type search model
    /// </returns>
    Task<ReviewTypeSearchModel> PrepareReviewTypeSearchModelAsync(ReviewTypeSearchModel searchModel);

    /// <summary>
    /// Prepare paged review type list model
    /// </summary>
    /// <param name="searchModel">Review type search model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the review type list model
    /// </returns>
    Task<ReviewTypeListModel> PrepareReviewTypeListModelAsync(ReviewTypeSearchModel searchModel);

    /// <summary>
    /// Prepare review type model
    /// </summary>
    /// <param name="model">Review type model</param>
    /// <param name="reviewType">Review type</param>
    /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the review type model
    /// </returns>
    Task<ReviewTypeModel> PrepareReviewTypeModelAsync(ReviewTypeModel model,
        ReviewType reviewType, bool excludeProperties = false);
}