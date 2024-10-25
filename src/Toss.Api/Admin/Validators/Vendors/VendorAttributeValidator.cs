using FluentValidation;
using Nop.Core.Domain.Vendors;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Vendors;

namespace Toss.Api.Admin.Validators.Vendors;

public partial class VendorAttributeValidator : BaseNopValidator<VendorAttributeModel>
{
    public VendorAttributeValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Vendors.VendorAttributes.Fields.Name.Required"));

        SetDatabaseValidationRules<VendorAttribute>();
    }
}