using FluentValidation;
using Nop.Core.Domain.Vendors;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Vendors;

namespace Toss.Api.Admin.Validators.Vendors;

public partial class VendorAttributeValueValidator : BaseNopValidator<VendorAttributeValueModel>
{
    public VendorAttributeValueValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Vendors.VendorAttributes.Values.Fields.Name.Required"));

        SetDatabaseValidationRules<VendorAttributeValue>();
    }
}