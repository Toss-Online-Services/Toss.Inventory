using FluentValidation;
using Nop.Core.Domain.Catalog;
using Nop.Services.Localization;
using Nop.Services.Seo;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Validators.Catalog;

public partial class ProductValidator : BaseNopValidator<ProductModel>
{
    public ProductValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.Products.Fields.Name.Required"));

        RuleFor(x => x.SeName)
            .Length(0, NopSeoDefaults.SearchEngineNameLength)
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.SearchEngineNameLength);

        RuleFor(x => x.RentalPriceLength)
            .GreaterThan(0)
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.Products.Fields.RentalPriceLength.ShouldBeGreaterThanZero"))
            .When(x => x.IsRental);

        SetDatabaseValidationRules<Product>();
    }
}