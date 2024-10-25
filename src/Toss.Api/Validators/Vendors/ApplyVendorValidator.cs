using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Models.Vendors;

namespace Toss.Api.Validators.Vendors;

public partial class ApplyVendorValidator : BaseNopValidator<ApplyVendorModel>
{
    public ApplyVendorValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Vendors.ApplyAccount.Name.Required"));

        RuleFor(x => x.Email).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Vendors.ApplyAccount.Email.Required"));
        RuleFor(x => x.Email)
            .IsEmailAddress()
            .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));
    }
}