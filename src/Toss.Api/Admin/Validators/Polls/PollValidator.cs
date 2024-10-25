using FluentValidation;
using Nop.Core.Domain.Polls;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Polls;

namespace Toss.Api.Admin.Validators.Polls;

public partial class PollValidator : BaseNopValidator<PollModel>
{
    public PollValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Fields.Name.Required"));

        SetDatabaseValidationRules<Poll>();
    }
}