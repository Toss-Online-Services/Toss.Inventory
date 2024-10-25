using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Vendors;

/// <summary>
/// Represents a vendor list model
/// </summary>
public partial record VendorListModel : BasePagedListModel<VendorModel>
{
}