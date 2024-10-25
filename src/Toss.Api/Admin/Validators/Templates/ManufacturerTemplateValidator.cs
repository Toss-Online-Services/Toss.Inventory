using FluentValidation;
using Nop.Core.Domain.Catalog;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Templates;

namespace Toss.Api.Admin.Validators.Templates;

public partial class ManufacturerTemplateValidator : BaseNopValidator<ManufacturerTemplateModel>
{
    public ManufacturerTemplateValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.System.Templates.Manufacturer.Name.Required"));
        RuleFor(x => x.ViewPath).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.System.Templates.Manufacturer.ViewPath.Required"));

        SetDatabaseValidationRules<ManufacturerTemplate>();
    }
}