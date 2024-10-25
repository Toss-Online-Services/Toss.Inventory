using FluentValidation;
using Nop.Core.Domain.Shipping;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Shipping;

namespace Toss.Api.Admin.Validators.Shipping;

public partial class ShippingMethodValidator : BaseNopValidator<ShippingMethodModel>
{
    public ShippingMethodValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Configuration.Shipping.Methods.Fields.Name.Required"));

        SetDatabaseValidationRules<ShippingMethod>();
    }
}