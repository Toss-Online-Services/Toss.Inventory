using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Logging;

/// <summary>
/// Represents an activity log type model
/// </summary>
public partial record ActivityLogTypeModel : BaseNopEntityModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Customers.ActivityLogType.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Customers.ActivityLogType.Fields.Enabled")]
    public bool Enabled { get; set; }

    #endregion
}