using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Vendors;

/// <summary>
/// Represents a vendor attribute value search model
/// </summary>
public partial record VendorAttributeValueSearchModel : BaseSearchModel
{
    #region Properties

    public int VendorAttributeId { get; set; }

    #endregion
}