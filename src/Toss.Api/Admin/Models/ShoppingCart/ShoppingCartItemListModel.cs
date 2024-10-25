using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.ShoppingCart;

/// <summary>
/// Represents a shopping cart item list model
/// </summary>
public partial record ShoppingCartItemListModel : BasePagedListModel<ShoppingCartItemModel>
{
}