using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Models.Customer;

namespace Toss.Api.Validators.Customer;

public partial class PasswordRecoveryValidator : BaseNopValidator<PasswordRecoveryModel>
{
    public PasswordRecoveryValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Email).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.PasswordRecovery.Email.Required"));
        RuleFor(x => x.Email)
            .IsEmailAddress()
            .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));
    }
}