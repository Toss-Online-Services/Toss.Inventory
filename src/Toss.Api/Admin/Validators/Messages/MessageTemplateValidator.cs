using FluentValidation;
using Nop.Core.Domain.Messages;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Admin.Models.Messages;

namespace Toss.Api.Admin.Validators.Messages;

public partial class MessageTemplateValidator : BaseNopValidator<MessageTemplateModel>
{
    public MessageTemplateValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Subject).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.ContentManagement.MessageTemplates.Fields.Subject.Required"));
        RuleFor(x => x.Body).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.ContentManagement.MessageTemplates.Fields.Body.Required"));

        SetDatabaseValidationRules<MessageTemplate>();
    }
}