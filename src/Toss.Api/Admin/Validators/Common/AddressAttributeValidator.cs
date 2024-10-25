using FluentValidation;
using Nop.Core.Domain.Common;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Common;

namespace Toss.Api.Admin.Validators.Common;

public partial class AddressAttributeValidator : BaseNopValidator<AddressAttributeModel>
{
    public AddressAttributeValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Address.AddressAttributes.Fields.Name.Required"));

        SetDatabaseValidationRules<AddressAttribute>();
    }
}