using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents an order note list model
/// </summary>
public partial record OrderNoteListModel : BasePagedListModel<OrderNoteModel>
{
}