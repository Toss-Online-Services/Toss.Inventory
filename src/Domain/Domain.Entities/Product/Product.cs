using System.Diagnostics;
using Domain.Entities.Catalog;
using Domain.Entities.Discounts;
using Domain.Entities.Events;
using Domain.Entities.Product.Commands;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Product
    : BaseAuditableEntity, IAggregateRoot, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported, Discounts.IDiscountSupported<DiscountProductMapping>
{

    public Product() { }
    public Product(CreateProductCommand command) {
        Apply(command);
    }

    private void Apply(CreateProductCommand command)
    {
        throw new NotImplementedException();
    }

    public bool SubjectToAcl { get; }
    public bool LimitedToStores { get; }
    // Identification
    public int ProductTypeId { get; private set; }
    public int ParentGroupedProductId { get; private set; }
    public bool VisibleIndividually { get; private set; }
    public string Name { get; private set; }

    // Descriptions
    public string ShortDescription { get; private set; }
    public string FullDescription { get; private set; }
    public string AdminComment { get; private set; }

    // Metadata
    public string MetaKeywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string MetaTitle { get; private set; }

    // Branding and Vendor
    public int ProductTemplateId { get; private set; }
    public int VendorId { get; private set; }

    // Pricing
    public Price Price { get; private set; }

    // Availability
    public Availability Availability { get; private set; }

    // Inventory
    public Inventory Inventory { get; private set; }

    // Shipping
    public Shipping Shipping { get; private set; }

    // Tax
    public Tax Tax { get; private set; }

    // Downloadable products
    public DownloadableProduct DownloadableProduct { get; private set; }

    // Gift cards
    public GiftCard GiftCard { get; private set; }

    // Recurring products
    public RecurringProduct RecurringProduct { get; private set; }

    // Rental products
    public RentalProduct RentalProduct { get; private set; }

    // Physical attributes
    public PhysicalAttributes PhysicalAttributes { get; private set; }

    // Compliance and Standards
    public ComplianceAndStandards ComplianceAndStandards { get; private set; }

    // Lifecycle
    public Lifecycle Lifecycle { get; private set; }

    // Display order
    public int DisplayOrder { get; private set; }

    // Status
    public bool Published { get; private set; }
    public bool Deleted { get; private set; }

    // Enum Mappings
    public ProductType ProductType { get; private set; }

    public BackorderMode BackorderMode { get; private set; }

    public DownloadActivationType DownloadActivationType { get; private set; }

    public GiftCardType GiftCardType { get; private set; }

    public LowStockActivity LowStockActivity { get; private set; }

    public ManageInventoryMethod ManageInventoryMethod { get; private set; }
    public RecurringProductCyclePeriod RecurringCyclePeriod { get; private set; }

    public RentalPricePeriod RentalPricePeriod { get; private set; }
    
}
