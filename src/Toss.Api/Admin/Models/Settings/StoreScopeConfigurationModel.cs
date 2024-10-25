using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Stores;

namespace Toss.Api.Admin.Models.Settings;

/// <summary>
/// Represents a store scope configuration model
/// </summary>
public partial record StoreScopeConfigurationModel : BaseNopModel
{
    #region Ctor

    public StoreScopeConfigurationModel()
    {
        Stores = new List<StoreModel>();
    }

    #endregion

    #region Properties

    public int StoreId { get; set; }

    public IList<StoreModel> Stores { get; set; }

    #endregion
}