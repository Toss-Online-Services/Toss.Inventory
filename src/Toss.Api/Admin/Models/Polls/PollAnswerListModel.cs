using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Polls;

/// <summary>
/// Represents a poll answer list model
/// </summary>
public partial record PollAnswerListModel : BasePagedListModel<PollAnswerModel>
{
}