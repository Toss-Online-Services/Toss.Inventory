using Web.Models.ShoppingCart;
namespace Web.Models.Customers;

/// <summary>
/// Represents a customer shopping cart list model
/// </summary>
public partial record CustomerShoppingCartListModel : BasePagedListModel<ShoppingCartItemModel>
{
}
