namespace Domain.Commands;

public record ProductCommand
{
    public bool SubjectToAcl { get; init; }
    public bool LimitedToStores { get; init; }

    // Identification
    public Guid ProductId { get; init; }
    public int ProductTypeId { get; init; }
    public int ParentGroupedProductId { get; init; }
    public bool VisibleIndividually { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string Sku { get; init; }
    public string Gtin { get; init; }
    public string ManufacturerPartNumber { get; init; }
    public string VendorPartNumber { get; init; }


    // Descriptions
    public string ShortDescription { get; init; }
    public string FullDescription { get; init; }
    public string AdminComment { get; init; }

    // Metadata
    public string MetaKeywords { get; init; }
    public string MetaDescription { get; init; }
    public string MetaTitle { get; init; }

    // Branding and Vendor
    public int ProductTemplateId { get; init; }
    public int VendorId { get; init; }

    // Display order
    public int DisplayOrder { get; init; }

    // Status
    public bool Published { get; init; }
    public bool Deleted { get; init; }
    public int BackorderModeId { get; init; }
    public int DownloadActivationTypeId { get; init; }
    public int LowStockActivityId { get; init; }
    public int ManageInventoryMethodId { get; init; }
    public int GiftCardTypeId { get; init; }
    public int RecurringCyclePeriodId { get; init; }
    public int RentalPricePeriodId { get; init; }


}
