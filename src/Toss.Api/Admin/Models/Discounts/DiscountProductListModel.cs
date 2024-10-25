using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount product list model
/// </summary>
public partial record DiscountProductListModel : BasePagedListModel<DiscountProductModel>
{
}