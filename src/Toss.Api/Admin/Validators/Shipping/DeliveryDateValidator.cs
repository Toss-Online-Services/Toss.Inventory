using FluentValidation;
using Nop.Core.Domain.Shipping;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Shipping;

namespace Toss.Api.Admin.Validators.Shipping;

public partial class DeliveryDateValidator : BaseNopValidator<DeliveryDateModel>
{
    public DeliveryDateValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Configuration.Shipping.DeliveryDates.Fields.Name.Required"));

        SetDatabaseValidationRules<DeliveryDate>();
    }
}