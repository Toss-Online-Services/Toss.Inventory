using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Validators.Catalog;

public partial class PredefinedProductAttributeValueModelValidator : BaseNopValidator<PredefinedProductAttributeValueModel>
{
    public PredefinedProductAttributeValueModelValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.Attributes.ProductAttributes.PredefinedValues.Fields.Name.Required"));
    }
}