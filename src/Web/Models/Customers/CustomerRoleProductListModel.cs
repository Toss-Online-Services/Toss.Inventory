using Web.Models.Catalog;
namespace Web.Models.Customers;

/// <summary>
/// Represents a customer role product list model
/// </summary>
public partial record CustomerRoleProductListModel : BasePagedListModel<ProductModel>
{
}
