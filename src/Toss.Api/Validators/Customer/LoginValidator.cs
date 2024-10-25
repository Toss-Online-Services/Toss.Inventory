using FluentValidation;
using Nop.Core.Domain.Customers;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Models.Customer;

namespace Toss.Api.Validators.Customer;

public partial class LoginValidator : BaseNopValidator<LoginModel>
{
    public LoginValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
    {
        if (!customerSettings.UsernamesEnabled)
        {
            //login by email
            RuleFor(x => x.Email).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.Login.Fields.Email.Required"));
            RuleFor(x => x.Email)
                .IsEmailAddress()
                .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));
        }
    }
}