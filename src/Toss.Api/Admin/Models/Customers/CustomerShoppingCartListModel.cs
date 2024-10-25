using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.ShoppingCart;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer shopping cart list model
/// </summary>
public partial record CustomerShoppingCartListModel : BasePagedListModel<ShoppingCartItemModel>
{
}