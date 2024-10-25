using FluentValidation;
using Nop.Core.Domain.Catalog;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Validators.Catalog;

public partial class ProductAttributeValidator : BaseNopValidator<ProductAttributeModel>
{
    public ProductAttributeValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.Attributes.ProductAttributes.Fields.Name.Required"));
        SetDatabaseValidationRules<ProductAttribute>();
    }
}