using FluentValidation;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Validators.Catalog;

public partial class ProductReviewValidator : BaseNopValidator<ProductReviewModel>
{
    public ProductReviewValidator(ILocalizationService localizationService, IWorkContext workContext)
    {
        var isLoggedInAsVendor = workContext.GetCurrentVendorAsync().Result != null;
        //vendor can edit "Reply text" only
        if (!isLoggedInAsVendor)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.ProductReviews.Fields.Title.Required"));
            RuleFor(x => x.ReviewText).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.ProductReviews.Fields.ReviewText.Required"));
        }

        SetDatabaseValidationRules<ProductReview>();
    }
}