namespace Web.Models.Customers;

/// <summary>
/// Represents a product model to add to the customer role 
/// </summary>
public partial record AddProductToCustomerRoleModel : BaseNopEntityModel
{
    #region Properties

    public int AssociatedToProductId { get; set; }

    #endregion
}
