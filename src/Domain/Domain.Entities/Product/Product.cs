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
    public Product() { }

    public Product(CreateProductCommand command)
    {
        Apply(command);
    }

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

        this.AddDomainEvent(new ProductCreatedDomainEvent(this));
    }

    public void Apply(UpdateProductCommand command)
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

        this.AddDomainEvent(new ProductUpdatedDomainEvent(this));
    }

    public void Apply(ProductDeletedEvent @event)
    {
        this.Deleted = true;
        this.AddDomainEvent(new ProductDeletedDomainEvent(this));
    }

    public void Apply(ProductPublishedDomainEvent @event)
    {
        this.Published = true;
        this.AddDomainEvent(new ProductPublishedDomainEvent(this));
    }

    public void Apply(ProductUnpublishedDomainEvent @event)
    {
        this.Published = false;
        this.AddDomainEvent(new ProductUnpublishedDomainEvent(this));
    }

    public void Apply(ProductReviewAddedDomainEvent @event)
    {
        // Handle product review added event
        this.AddDomainEvent(new ProductReviewAddedDomainEvent(this, @event.Review));
    }

    public void Apply(ProductReviewUpdatedDomainEvent @event)
    {
        // Handle product review updated event
        this.AddDomainEvent(new ProductReviewUpdatedDomainEvent(this, @event.Review));
    }

    public void Apply(ProductReviewDeletedDomainEvent @event)
    {
        // Handle product review deleted event
        this.AddDomainEvent(new ProductReviewDeletedDomainEvent(this, @event.Review));
    }

    public void Apply(ProductInventoryAdjustedDomainEvent @event)
    {
        // Handle product inventory adjusted event
       
        this.AddDomainEvent(new ProductInventoryAdjustedDomainEvent(this, @event.OldQuantity, @event.NewQuantity));
    }

    public void Apply(ProductStockQuantityChangedDomainEvent @event)
    {
        // Handle product stock quantity changed event        
        this.AddDomainEvent(new ProductStockQuantityChangedDomainEvent(this, @event.OldQuantity, @event.NewQuantity));
    }

    public void Apply(ProductPriceChangedEvent @event)
    {
        // Handle product price changed event
        this.AddDomainEvent(new ProductPriceChangedDomainEvent(this, @event.OldPrice, @event.NewPrice));
    }

    // Add other event handling methods as needed
}
