using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a return request list model
/// </summary>
public partial record ReturnRequestListModel : BasePagedListModel<ReturnRequestModel>
{
}