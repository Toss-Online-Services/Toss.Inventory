using FluentValidation;
using Nop.Core.Domain.Customers;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Customers;

namespace Toss.Api.Admin.Validators.Customers;

public partial class CustomerRoleValidator : BaseNopValidator<CustomerRoleModel>
{
    public CustomerRoleValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Customers.CustomerRoles.Fields.Name.Required"));

        SetDatabaseValidationRules<CustomerRole>();
    }
}