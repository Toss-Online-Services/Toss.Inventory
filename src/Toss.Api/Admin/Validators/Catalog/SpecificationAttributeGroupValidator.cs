using FluentValidation;
using Nop.Core.Domain.Catalog;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Validators.Catalog;

/// <summary>
/// Represents a validator for <see cref="SpecificationAttributeGroupModel"/>
/// </summary>
public partial class SpecificationAttributeGroupValidator : BaseNopValidator<SpecificationAttributeGroupModel>
{
    public SpecificationAttributeGroupValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Fields.Name.Required"));

        SetDatabaseValidationRules<SpecificationAttributeGroup>();
    }
}