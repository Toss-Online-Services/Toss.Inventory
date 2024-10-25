using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Vendors;

/// <summary>
/// Represents a vendor note list model
/// </summary>
public partial record VendorNoteListModel : BasePagedListModel<VendorNoteModel>
{
}