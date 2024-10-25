using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Affiliates;

/// <summary>
/// Represents an affiliated customer list model
/// </summary>
public partial record AffiliatedCustomerListModel : BasePagedListModel<AffiliatedCustomerModel>
{
}