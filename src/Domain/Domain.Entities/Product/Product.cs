using AutoMapper;
using Domain.Entities.Catalog;
using Domain.Entities.Discounts;
using Domain.Entities.Product.Commands;
using Domain.Entities.Product.Events;
using Domain.Infrastructure;
using System.Threading.Tasks;

namespace Domain.Entities.Product;

public sealed class Product
    : BaseAuditableEntity, IAggregateRoot, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported, Discounts.IDiscountSupported<DiscountProductMapping>
{
    public Product() {
        Price = new();
        Availability = new();
        Inventory = new();
        Shipping = new();
        Tax = new();
        DownloadableProduct = new();
        GiftCard = new();
        RecurringProduct = new();
        RentalProduct = new();
        PhysicalAttributes = new();
        ComplianceAndStandards = new();
        Lifecycle = new();

    }

    public Product(CreateProductCommand command):this()
    {
        Apply(command);
    }

    public string ProductId { get; set; }
    public bool SubjectToAcl { get; private set; }
    public bool LimitedToStores { get; private set; }

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

    // Methods to handle events
    private void Apply(CreateProductCommand command)
    {
        SubjectToAcl = command.SubjectToAcl;
        LimitedToStores = command.LimitedToStores;
        ProductTypeId = command.ProductTypeId;
        ParentGroupedProductId = command.ParentGroupedProductId;
        VisibleIndividually = command.VisibleIndividually;
        Name = command.Name;
        ShortDescription = command.ShortDescription;
        FullDescription = command.FullDescription;
        AdminComment = command.AdminComment;
        MetaKeywords = command.MetaKeywords;
        MetaDescription = command.MetaDescription;
        MetaTitle = command.MetaTitle;
        ProductTemplateId = command.ProductTemplateId;
        VendorId = command.VendorId;
        DisplayOrder = command.DisplayOrder;
        Published = command.Published;
        Deleted = command.Deleted;


        ProductType = (ProductType)command.ProductTypeId;
        BackorderMode = (BackorderMode)command.BackorderModeId;
        DownloadActivationType = (DownloadActivationType)command.DownloadActivationTypeId;
        GiftCardType = (GiftCardType)command.GiftCardTypeId;
        LowStockActivity = (LowStockActivity)command.LowStockActivityId;
        ManageInventoryMethod = (ManageInventoryMethod)command.ManageInventoryMethodId;
        RecurringCyclePeriod = (RecurringProductCyclePeriod)command.RecurringCyclePeriodId;
        RentalPricePeriod = (RentalPricePeriod)command.RentalPricePeriodId;

        Price.Apply(command.Price);
        Availability.Apply(command.Availability);
        Inventory.Apply(command.Inventory);
        Shipping.Apply(command.Shipping);

        AddDomainEvent(new ProductCreatedDomainEvent(this));
    }

    public void UpdateAvailability(UpdateAvailabilityCommand availabilityCommand)
    {
        Availability.Apply(availabilityCommand);
        AddDomainEvent(new ProductAvailabilityUpdatedDomainEvent(ProductId, Availability));
    }

    public void UpdateShipping(UpdateShippingCommand shippingCommand)
    {
        Shipping.Apply(shippingCommand);
        AddDomainEvent(new ProductShippingUpdatedDomainEvent(ProductId, Shipping));
    }

    public void UpdateInventory(UpdateInventoryCommand inventoryCommand)
    {
        Inventory.Apply(inventoryCommand);
        AddDomainEvent(new ProductInventoryUpdatedDomainEvent(ProductId, Inventory));
    }

    public void AddPrice(UpdatePriceCommand priceCommand)
    {
        Price.Apply(priceCommand);
        AddDomainEvent(new ProductPriceUpdatedDomainEvent(ProductId, Price));
    }

    public void Update(UpdateProductCommand command)
    {
        // Update properties based on the event
        
        SubjectToAcl = command.SubjectToAcl;
        LimitedToStores = command.LimitedToStores;
        ProductTypeId = command.ProductTypeId;
        ParentGroupedProductId = command.ParentGroupedProductId;
        VisibleIndividually = command.VisibleIndividually;
        Name = command.Name;
        ShortDescription = command.ShortDescription;
        FullDescription = command.FullDescription;
        AdminComment = command.AdminComment;
        MetaKeywords = command.MetaKeywords;
        MetaDescription = command.MetaDescription;
        MetaTitle = command.MetaTitle;
        ProductTemplateId = command.ProductTemplateId;
        VendorId = command.VendorId;
        DisplayOrder = command.DisplayOrder;
        Published = command.Published;
        Deleted = command.Deleted;
        ProductType = (ProductType)command.ProductTypeId;
        BackorderMode = (BackorderMode)command.BackorderModeId;
        DownloadActivationType = (DownloadActivationType)command.DownloadActivationTypeId;
        GiftCardType = (GiftCardType)command.GiftCardTypeId;
        LowStockActivity = (LowStockActivity)command.LowStockActivityId;
        ManageInventoryMethod = (ManageInventoryMethod)command.ManageInventoryMethodId;
        RecurringCyclePeriod = (RecurringProductCyclePeriod)command.RecurringCyclePeriodId;
        RentalPricePeriod = (RentalPricePeriod)command.RentalPricePeriodId;

        AddDomainEvent(new ProductUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        Deleted = true;
        AddDomainEvent(new ProductDeletedDomainEvent(this));
    }

    public void Publish()
    {
        Published = true;
        AddDomainEvent(new ProductPublishedDomainEvent(this));
    }

    public void UnPublish()
    {
        Published = false;
        AddDomainEvent(new ProductUnpublishedDomainEvent(this));
    }
    
}
