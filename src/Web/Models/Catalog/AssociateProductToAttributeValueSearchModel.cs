using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models.Catalog;

/// <summary>
/// Represents a product search model to associate to the product attribute value
/// </summary>
public partial record AssociateProductToAttributeValueSearchModel : BaseSearchModel
{
    #region Ctor

    public AssociateProductToAttributeValueSearchModel()
    {
        AvailableCategories = new List<SelectListItem>();
        AvailableManufacturers = new List<SelectListItem>();
        AvailableStores = new List<SelectListItem>();
        AvailableVendors = new List<SelectListItem>();
        AvailableProductTypes = new List<SelectListItem>();
        AssociateProductToAttributeValueModel = new AssociateProductToAttributeValueModel();
        SearchProductName = string.Empty;
    }

    #endregion

    #region Properties

   
    public string SearchProductName { get; set; }

   
    public int SearchCategoryId { get; set; }

   
    public int SearchManufacturerId { get; set; }

   
    public int SearchStoreId { get; set; }

   
    public int SearchVendorId { get; set; }

   
    public int SearchProductTypeId { get; set; }

    public IList<SelectListItem> AvailableCategories { get; set; }

    public IList<SelectListItem> AvailableManufacturers { get; set; }

    public IList<SelectListItem> AvailableStores { get; set; }

    public IList<SelectListItem> AvailableVendors { get; set; }

    public IList<SelectListItem> AvailableProductTypes { get; set; }

    public bool IsLoggedInAsVendor { get; set; }

    public AssociateProductToAttributeValueModel AssociateProductToAttributeValueModel { get; set; }

    #endregion
}
