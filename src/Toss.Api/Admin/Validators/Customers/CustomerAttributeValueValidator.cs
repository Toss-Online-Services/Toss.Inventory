using FluentValidation;
using Nop.Core.Domain.Customers;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Customers;

namespace Toss.Api.Admin.Validators.Customers;

public partial class CustomerAttributeValueValidator : BaseNopValidator<CustomerAttributeValueModel>
{
    public CustomerAttributeValueValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Customers.CustomerAttributes.Values.Fields.Name.Required"));

        SetDatabaseValidationRules<CustomerAttributeValue>();
    }
}