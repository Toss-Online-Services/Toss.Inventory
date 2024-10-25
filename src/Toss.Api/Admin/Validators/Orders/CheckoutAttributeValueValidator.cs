using FluentValidation;
using Nop.Core.Domain.Orders;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Orders;

namespace Toss.Api.Admin.Validators.Orders;

public partial class CheckoutAttributeValueValidator : BaseNopValidator<CheckoutAttributeValueModel>
{
    public CheckoutAttributeValueValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name.Required"));

        SetDatabaseValidationRules<CheckoutAttributeValue>();
    }
}