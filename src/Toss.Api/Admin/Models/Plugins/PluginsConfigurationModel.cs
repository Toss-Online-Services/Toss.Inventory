using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Plugins.Marketplace;

namespace Toss.Api.Admin.Models.Plugins;

/// <summary>
/// Represents a plugins configuration model
/// </summary>
public partial record PluginsConfigurationModel : BaseNopModel
{
    #region Ctor

    public PluginsConfigurationModel()
    {
        PluginsLocal = new PluginSearchModel();
        AllPluginsAndThemes = new OfficialFeedPluginSearchModel();
    }

    #endregion

    #region Properties

    public PluginSearchModel PluginsLocal { get; set; }

    public OfficialFeedPluginSearchModel AllPluginsAndThemes { get; set; }

    #endregion
}