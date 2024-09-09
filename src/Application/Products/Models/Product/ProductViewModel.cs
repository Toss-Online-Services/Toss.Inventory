namespace Application.Products.Models.Product;
























// Identification
// Descriptions
// Metadata
// Branding and Vendor
// Display order
// Status
// Pricing
// Availability
// Inventory
// Shipping
// Tax
// Downloadable products
// Gift cards
// Recurring products
// Rental products
// Physical attributes
// Compliance and Standards
// Lifecycle
// Enum Mappings
/// <param name="Components"></param>
/// <param name="SubjectToAcl"></param>
/// <param name="LimitedToStores"></param>
/// <param name="ProductId"></param>
/// <param name="ProductTypeId"></param>
/// <param name="ParentGroupedProductId"></param>
/// <param name="VisibleIndividually"></param>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Sku"></param>
/// <param name="Gtin"></param>
/// <param name="ManufacturerPartNumber"></param>
/// <param name="VendorPartNumber"></param>
/// <param name="ShortDescription"></param>
/// <param name="FullDescription"></param>
/// <param name="AdminComment"></param>
/// <param name="MetaKeywords"></param>
/// <param name="MetaDescription"></param>
/// <param name="MetaTitle"></param>
/// <param name="ProductTemplateId"></param>
/// <param name="VendorId"></param>
/// <param name="DisplayOrder"></param>
/// <param name="Published"></param>
/// <param name="Deleted"></param>
/// <param name="RequiredProductIds"> Gets or sets a required product identifiers (comma separated) </param>
/// <param name="AllowedQuantities"> Gets or sets the comma separated list of allowed quantities. null or empty if any quantity is allowed </param>
/// <param name="Price"></param>
/// <param name="Availability"></param>
/// <param name="Inventory"></param>
/// <param name="Shipping"></param>
/// <param name="Tax"></param>
/// <param name="DownloadableProduct"></param>
/// <param name="GiftCard"></param>
/// <param name="RecurringProduct"></param>
/// <param name="RentalProduct"></param>
/// <param name="PhysicalAttributes"></param>
/// <param name="ComplianceAndStandards"></param>
/// <param name="Lifecycle"></param>
/// <param name="ProductType"></param>
/// <param name="BackorderMode"></param>
/// <param name="DownloadActivationType"></param>
/// <param name="GiftCardType"></param>
/// <param name="LowStockActivity"></param>
/// <param name="ManageInventoryMethod"></param>
/// <param name="RecurringCyclePeriod"></param>
/// <param name="RentalPricePeriod"></param>
public sealed record ProductViewModel(
                                      List<ProductComponentViewModel> Components, 
                                      bool SubjectToAcl, 
                                      bool LimitedToStores, 
                                      Guid ProductId, 
                                      int ProductTypeId, 
                                      int ParentGroupedProductId, 
                                      bool VisibleIndividually, 
                                      string Name, 
                                      string Description, 
                                      string Sku, 
                                      string Gtin, 
                                      string ManufacturerPartNumber, 
                                      string VendorPartNumber, 
                                      string ShortDescription, 
                                      string FullDescription, 
                                      string AdminComment, 
                                      string MetaKeywords, 
                                      string MetaDescription, 
                                      string MetaTitle, 
                                      int ProductTemplateId, 
                                      int VendorId, 
                                      int DisplayOrder, 
                                      bool Published, 
                                      bool Deleted, 
                                      string RequiredProductIds, 
                                      string AllowedQuantities, 
                                      PriceViewModel Price, 
                                      AvailabilityViewModel Availability, 
                                      InventoryViewModel Inventory, 
                                      ShippingViewModel Shipping, 
                                      TaxViewModel Tax, 
                                      DownloadableProductViewModel DownloadableProduct, 
                                      GiftCardViewModel GiftCard, 
                                      RecurringProductViewModel RecurringProduct, 
                                      RentalProductViewModel RentalProduct, 
                                      PhysicalAttributesViewModel PhysicalAttributes, 
                                      ComplianceAndStandardsViewModel ComplianceAndStandards, 
                                      LifecycleViewModel Lifecycle, 
                                      ProductType ProductType, 
                                      BackorderMode BackorderMode, 
                                      DownloadActivationType DownloadActivationType, 
                                      GiftCardType GiftCardType, 
                                      LowStockActivity LowStockActivity, 
                                      ManageInventoryMethod ManageInventoryMethod, 
                                      RecurringProductCyclePeriod RecurringCyclePeriod, 
                                      RentalPricePeriod RentalPricePeriod
                                    )
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductViewModel, Domain.Entities.Product>().ReverseMap();
        }
    }
}
