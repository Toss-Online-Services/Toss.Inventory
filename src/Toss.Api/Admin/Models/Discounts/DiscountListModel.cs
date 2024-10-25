using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount list model
/// </summary>
public partial record DiscountListModel : BasePagedListModel<DiscountModel>
{
}