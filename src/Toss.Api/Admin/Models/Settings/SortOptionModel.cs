using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Settings;

/// <summary>
/// Represents a sort option model
/// </summary>
public partial record SortOptionModel : BaseNopEntityModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.IsActive")]
    public bool IsActive { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.DisplayOrder")]
    public int DisplayOrder { get; set; }

    #endregion
}