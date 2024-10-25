using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Logging;

/// <summary>
/// Represents an activity log type search model
/// </summary>
public partial record ActivityLogTypeSearchModel : BaseSearchModel
{
    #region Properties       

    public IList<ActivityLogTypeModel> ActivityLogTypeListModel { get; set; }

    #endregion
}