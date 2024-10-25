using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Affiliates;

/// <summary>
/// Represents an affiliate list model
/// </summary>
public partial record AffiliateListModel : BasePagedListModel<AffiliateModel>
{
}