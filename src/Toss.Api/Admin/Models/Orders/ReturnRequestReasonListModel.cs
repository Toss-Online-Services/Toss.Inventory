using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a return request reason list model
/// </summary>
public partial record ReturnRequestReasonListModel : BasePagedListModel<ReturnRequestReasonModel>
{
}