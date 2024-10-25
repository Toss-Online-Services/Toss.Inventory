using FluentValidation;
using Nop.Core.Domain.Customers;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Customers;

namespace Toss.Api.Admin.Validators.Customers;

public partial class CustomerAttributeValidator : BaseNopValidator<CustomerAttributeModel>
{
    public CustomerAttributeValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Customers.CustomerAttributes.Fields.Name.Required"));

        SetDatabaseValidationRules<CustomerAttribute>();
    }
}