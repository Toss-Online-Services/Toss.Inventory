using FluentValidation;
using Nop.Core.Domain.Catalog;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Validators.Catalog;

/// <summary>
/// Represent a review type validator
/// </summary>
public partial class ReviewTypeValidator : BaseNopValidator<ReviewTypeModel>
{
    public ReviewTypeValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Settings.ReviewType.Fields.Name.Required"));
        RuleFor(x => x.Description).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Settings.ReviewType.Fields.Description.Required"));

        SetDatabaseValidationRules<ReviewType>();
    }
}