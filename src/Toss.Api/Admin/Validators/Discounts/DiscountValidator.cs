using FluentValidation;
using Nop.Core.Domain.Discounts;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Discounts;

namespace Toss.Api.Admin.Validators.Discounts;

public partial class DiscountValidator : BaseNopValidator<DiscountModel>
{
    public DiscountValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Promotions.Discounts.Fields.Name.Required"));

        SetDatabaseValidationRules<Discount>();
    }
}