using FluentValidation;
using Nop.Core.Domain.Common;
using Nop.Services.Localization;
using Toss.Api.Admin.Models.Customers;
using Toss.Api.Admin.Validators.Common;

namespace Toss.Api.Admin.Validators.Customers;

public partial class CustomerAddressValidator : AbstractValidator<CustomerAddressModel>
{
    public CustomerAddressValidator(ILocalizationService localizationService,
        AddressSettings addressSettings)
    {
        RuleFor(model => model.Address).SetValidator(new AddressValidator(addressSettings, localizationService));
    }
}
