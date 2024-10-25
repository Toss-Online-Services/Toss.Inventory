using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a manufacturer product search model
/// </summary>
public partial record ManufacturerProductSearchModel : BaseSearchModel
{
    #region Properties

    public int ManufacturerId { get; set; }

    #endregion
}