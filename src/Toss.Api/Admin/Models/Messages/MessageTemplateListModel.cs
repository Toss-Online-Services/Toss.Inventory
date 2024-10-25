using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Messages;

/// <summary>
/// Represents a message template list model
/// </summary>
public partial record MessageTemplateListModel : BasePagedListModel<MessageTemplateModel>
{
}