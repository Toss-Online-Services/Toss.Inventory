using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Settings;

/// <summary>
/// Represents a setting mode model
/// </summary>
public partial record SettingModeModel : BaseNopModel
{
    #region Properties

    public string ModeName { get; set; }

    public bool Enabled { get; set; }

    #endregion
}