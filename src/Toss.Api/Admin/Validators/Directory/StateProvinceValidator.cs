using FluentValidation;
using Nop.Core.Domain.Directory;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Directory;

namespace Toss.Api.Admin.Validators.Directory;

public partial class StateProvinceValidator : BaseNopValidator<StateProvinceModel>
{
    public StateProvinceValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Configuration.Countries.States.Fields.Name.Required"));

        SetDatabaseValidationRules<StateProvince>();
    }
}