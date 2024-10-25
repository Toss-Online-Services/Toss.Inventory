using FluentValidation;
using Nop.Core.Domain.Forums;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Forums;

namespace Toss.Api.Admin.Validators.Forums;

public partial class ForumGroupValidator : BaseNopValidator<ForumGroupModel>
{
    public ForumGroupValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.ContentManagement.Forums.ForumGroup.Fields.Name.Required"));

        SetDatabaseValidationRules<ForumGroup>();
    }
}