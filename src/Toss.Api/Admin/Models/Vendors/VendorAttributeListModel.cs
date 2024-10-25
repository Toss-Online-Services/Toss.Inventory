using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Vendors;

/// <summary>
/// Represents a vendor attribute list model
/// </summary>
public partial record VendorAttributeListModel : BasePagedListModel<VendorAttributeModel>
{
}