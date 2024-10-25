using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Tasks;

/// <summary>
/// Represents a schedule task list model
/// </summary>
public partial record ScheduleTaskListModel : BasePagedListModel<ScheduleTaskModel>
{
}