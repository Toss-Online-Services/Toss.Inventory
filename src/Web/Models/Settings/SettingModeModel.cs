namespace Web.Models.Settings;

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