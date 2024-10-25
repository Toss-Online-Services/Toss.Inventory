using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a return request action list model
/// </summary>
public partial record ReturnRequestActionListModel : BasePagedListModel<ReturnRequestActionModel>
{
}