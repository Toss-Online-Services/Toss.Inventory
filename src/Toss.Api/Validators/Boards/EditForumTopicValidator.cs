using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Models.Boards;

namespace Toss.Api.Validators.Boards;

public partial class EditForumTopicValidator : BaseNopValidator<EditForumTopicModel>
{
    public EditForumTopicValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Subject).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Forum.TopicSubjectCannotBeEmpty"));
        RuleFor(x => x.Text).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Forum.TextCannotBeEmpty"));
    }
}