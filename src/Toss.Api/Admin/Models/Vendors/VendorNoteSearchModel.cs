using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Vendors;

/// <summary>
/// Represents a vendor note search model
/// </summary>
public partial record VendorNoteSearchModel : BaseSearchModel
{
    #region Properties

    public int VendorId { get; set; }

    #endregion
}