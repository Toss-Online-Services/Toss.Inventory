using Web.Models.Catalog;

namespace Web.Models.Orders;

/// <summary>
/// Represents a product list model to add to the order
/// </summary>
public partial record AddProductToOrderListModel : BasePagedListModel<ProductModel>
{
}
