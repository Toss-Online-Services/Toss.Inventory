using FluentValidation;
using Nop.Core.Domain.Orders;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Orders;

namespace Toss.Api.Admin.Validators.Orders;

public partial class ReturnRequestReasonValidator : BaseNopValidator<ReturnRequestReasonModel>
{
    public ReturnRequestReasonValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Configuration.Settings.Order.ReturnRequestReasons.Name.Required"));

        SetDatabaseValidationRules<ReturnRequestReason>();
    }
}