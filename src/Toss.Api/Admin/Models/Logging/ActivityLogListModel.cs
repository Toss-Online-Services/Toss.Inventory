using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Logging;

/// <summary>
/// Represents an activity log list model
/// </summary>
public partial record ActivityLogListModel : BasePagedListModel<ActivityLogModel>
{
}