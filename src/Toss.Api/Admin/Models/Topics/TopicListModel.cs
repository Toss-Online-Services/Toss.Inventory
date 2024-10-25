using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Topics;

/// <summary>
/// Represents a topic list model
/// </summary>
public partial record TopicListModel : BasePagedListModel<TopicModel>
{
}