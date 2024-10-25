using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.ShoppingCart;

/// <summary>
/// Represents a shopping cart list model
/// </summary>
public partial record ShoppingCartListModel : BasePagedListModel<ShoppingCartModel>
{
}