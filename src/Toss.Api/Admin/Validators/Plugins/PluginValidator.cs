using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Plugins;

namespace Toss.Api.Admin.Validators.Plugins;

public partial class PluginValidator : BaseNopValidator<PluginModel>
{
    public PluginValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.FriendlyName).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Configuration.Plugins.Fields.FriendlyName.Required"));
    }
}