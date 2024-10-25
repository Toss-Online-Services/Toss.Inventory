using FluentValidation;
using Nop.Core.Domain.Messages;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Messages;

namespace Toss.Api.Admin.Validators.Messages;

public partial class CampaignValidator : BaseNopValidator<CampaignModel>
{
    public CampaignValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Promotions.Campaigns.Fields.Name.Required"));

        RuleFor(x => x.Subject).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Promotions.Campaigns.Fields.Subject.Required"));

        RuleFor(x => x.Body).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Promotions.Campaigns.Fields.Body.Required"));

        SetDatabaseValidationRules<Campaign>();
    }
}