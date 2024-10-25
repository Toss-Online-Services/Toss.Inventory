using FluentValidation;
using Nop.Core.Domain.Catalog;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Validators.Catalog;

public partial class ProductTagValidator : BaseNopValidator<ProductTagModel>
{
    public ProductTagValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.ProductTags.Fields.Name.Required"));

        SetDatabaseValidationRules<ProductTag>();
    }
}