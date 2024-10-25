using FluentValidation;
using Nop.Core.Domain.Shipping;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Shipping;

namespace Toss.Api.Admin.Validators.Shipping;

public partial class WarehouseValidator : BaseNopValidator<WarehouseModel>
{
    public WarehouseValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Configuration.Shipping.Warehouses.Fields.Name.Required"));

        SetDatabaseValidationRules<Warehouse>();
    }
}