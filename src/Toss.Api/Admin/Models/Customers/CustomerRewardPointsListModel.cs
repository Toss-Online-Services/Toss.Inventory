using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a reward points list model
/// </summary>
public partial record CustomerRewardPointsListModel : BasePagedListModel<CustomerRewardPointsModel>
{
}