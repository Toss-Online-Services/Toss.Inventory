using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models.Customers;

/// <summary>
/// Represents a customer shopping cart search model
/// </summary>
public partial record CustomerShoppingCartSearchModel : BaseSearchModel
{
    #region Ctor

    public CustomerShoppingCartSearchModel()
    {
        AvailableShoppingCartTypes = new List<SelectListItem>();
    }

    #endregion

    #region Properties

    public int CustomerId { get; set; }

    [NopResourceDisplayName("Admin.ShoppingCartType.ShoppingCartType")]
    public int ShoppingCartTypeId { get; set; }

    public IList<SelectListItem> AvailableShoppingCartTypes { get; set; }

    #endregion
}