using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Home;

/// <summary>
/// Represents a dashboard model
/// </summary>
public partial record DashboardModel : BaseNopModel
{
    #region Properties

    public bool IsLoggedInAsVendor { get; set; }

    #endregion
}