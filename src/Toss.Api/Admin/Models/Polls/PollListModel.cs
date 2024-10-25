using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Polls;

/// <summary>
/// Represents a poll list model
/// </summary>
public partial record PollListModel : BasePagedListModel<PollModel>
{
}