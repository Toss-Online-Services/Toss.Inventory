using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Models.Catalog;

namespace Toss.Api.Validators.Catalog;

public partial class ProductEmailAFriendValidator : BaseNopValidator<ProductEmailAFriendModel>
{
    public ProductEmailAFriendValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.FriendEmail).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Products.EmailAFriend.FriendEmail.Required"));
        RuleFor(x => x.FriendEmail)
            .IsEmailAddress()
            .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));

        RuleFor(x => x.YourEmailAddress).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Products.EmailAFriend.YourEmailAddress.Required"));
        RuleFor(x => x.YourEmailAddress)
            .IsEmailAddress()
            .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));
    }
}