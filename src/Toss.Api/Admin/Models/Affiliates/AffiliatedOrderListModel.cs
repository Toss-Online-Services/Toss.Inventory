using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Affiliates;

/// <summary>
/// Represents an affiliated order list model
/// </summary>
public partial record AffiliatedOrderListModel : BasePagedListModel<AffiliatedOrderModel>
{
}