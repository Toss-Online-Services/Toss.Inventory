using FluentValidation;
using Nop.Core.Domain.Common;
using Nop.Services.Localization;
using Toss.Api.Admin.Models.Orders;
using Toss.Api.Admin.Validators.Common;

namespace Toss.Api.Admin.Validators.Orders;

public partial class OrderAddressValidator : AbstractValidator<OrderAddressModel>
{
    public OrderAddressValidator(ILocalizationService localizationService,
        AddressSettings addressSettings)
    {
        RuleFor(model => model.Address).SetValidator(new AddressValidator(addressSettings, localizationService));
    }
}
