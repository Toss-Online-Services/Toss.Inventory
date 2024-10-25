using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Shipping;

/// <summary>
/// Represents a product availability range list model
/// </summary>
public partial record ProductAvailabilityRangeListModel : BasePagedListModel<ProductAvailabilityRangeModel>
{
}