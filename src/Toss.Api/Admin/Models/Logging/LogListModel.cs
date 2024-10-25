using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Logging;

/// <summary>
/// Represents a log list model
/// </summary>
public partial record LogListModel : BasePagedListModel<LogModel>
{
}