using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a tier price list model
/// </summary>
public partial record TierPriceListModel : BasePagedListModel<TierPriceModel>
{
}