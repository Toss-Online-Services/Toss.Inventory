using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models.Catalog;

/// <summary>
/// Represents an associated product search model to add to the product
/// </summary>
public partial record AddAssociatedProductSearchModel : BaseSearchModel
{
    #region Ctor

    public AddAssociatedProductSearchModel()
    {
        AvailableCategories = new List<SelectListItem>();
        AvailableManufacturers = new List<SelectListItem>();
        AvailableStores = new List<SelectListItem>();
        AvailableVendors = new List<SelectListItem>();
        AvailableProductTypes = new List<SelectListItem>();
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

    public int ProductId { get; set; }

    #endregion
}
