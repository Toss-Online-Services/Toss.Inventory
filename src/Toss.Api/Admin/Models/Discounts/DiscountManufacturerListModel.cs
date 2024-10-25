using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount manufacturer list model
/// </summary>
public partial record DiscountManufacturerListModel : BasePagedListModel<DiscountManufacturerModel>
{
}