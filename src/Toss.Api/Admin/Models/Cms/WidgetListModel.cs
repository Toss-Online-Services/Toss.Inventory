using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Cms;

/// <summary>
/// Represents a widget list model
/// </summary>
public partial record WidgetListModel : BasePagedListModel<WidgetModel>
{
}