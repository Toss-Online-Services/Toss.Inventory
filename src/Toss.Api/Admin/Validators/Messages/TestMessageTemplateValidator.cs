using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Messages;

namespace Toss.Api.Admin.Validators.Messages;

public partial class TestMessageTemplateValidator : BaseNopValidator<TestMessageTemplateModel>
{
    public TestMessageTemplateValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.SendTo).NotEmpty();
        RuleFor(x => x.SendTo)
            .IsEmailAddress()
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Common.WrongEmail"));
    }
}