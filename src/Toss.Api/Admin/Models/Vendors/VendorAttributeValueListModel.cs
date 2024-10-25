using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Vendors;

/// <summary>
/// Represents a vendor attribute value list model
/// </summary>
public partial record VendorAttributeValueListModel : BasePagedListModel<VendorAttributeValueModel>
{
}