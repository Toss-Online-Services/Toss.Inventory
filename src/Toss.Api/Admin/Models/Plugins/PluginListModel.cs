using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Plugins;

/// <summary>
/// Represents a plugin list model
/// </summary>
public partial record PluginListModel : BasePagedListModel<PluginModel>
{
}