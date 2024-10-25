using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Models.Boards;

namespace Toss.Api.Validators.Boards;

public partial class EditForumPostValidator : BaseNopValidator<EditForumPostModel>
{
    public EditForumPostValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Text).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Forum.TextCannotBeEmpty"));
    }
}