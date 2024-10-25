using FluentValidation;
using Nop.Core.Domain.ScheduleTasks;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Tasks;

namespace Toss.Api.Admin.Validators.Tasks;

public partial class ScheduleTaskValidator : BaseNopValidator<ScheduleTaskModel>
{
    public ScheduleTaskValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.System.ScheduleTasks.Name.Required"));
        RuleFor(x => x.Seconds).GreaterThan(0).WithMessageAwait(localizationService.GetResourceAsync("Admin.System.ScheduleTasks.Seconds.Positive"));

        SetDatabaseValidationRules<ScheduleTask>();
    }
}