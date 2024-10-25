using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Models.PrivateMessages;

namespace Toss.Api.Validators.PrivateMessages;

public partial class SendPrivateMessageValidator : BaseNopValidator<SendPrivateMessageModel>
{
    public SendPrivateMessageValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Subject).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("PrivateMessages.SubjectCannotBeEmpty"));
        RuleFor(x => x.Message).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("PrivateMessages.MessageCannotBeEmpty"));
    }
}