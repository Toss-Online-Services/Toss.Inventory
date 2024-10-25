using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Templates;

/// <summary>
/// Represents a topic template list model
/// </summary>
public partial record TopicTemplateListModel : BasePagedListModel<TopicTemplateModel>
{
}