namespace Web.Models.Settings;

/// <summary>
/// Represents a cache configuration model
/// </summary>
public partial record CacheConfigModel : BaseNopModel, IConfigModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Configuration.AppSettings.Cache.DefaultCacheTime")]
    public int DefaultCacheTime { get; set; }

    [NopResourceDisplayName("Admin.Configuration.AppSettings.Cache.LinqDisableQueryCache")]
    public bool LinqDisableQueryCache { get; set; }

    #endregion
}