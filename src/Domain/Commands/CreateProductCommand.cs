namespace Domain.Commands;

public record CreateProductCommand : ProductCommand, ICommand<bool>
{
    public UpdatePriceCommand Price { get; init; }
    public UpdateAvailabilityCommand Availability { get; init; }
    public UpdateInventoryCommand Inventory { get; init; }
    public UpdateShippingCommand Shipping { get; init; }
    public UpdateTaxCommand Tax { get; init; }
    public UpdateDownloadableProductCommand DownloadableProduct { get; init; }
    public UpdateGiftCardCommand GiftCard { get; init; }
    public UpdateRecurringProductCommand RecurringProduct { get; init; }
    public UpdateRentalProductCommand RentalProduct { get; init; }
    public UpdatePhysicalAttributesCommand PhysicalAttributes { get; init; }
    public UpdateComplianceAndStandardsCommand ComplianceAndStandards { get; init; }
    public UpdateLifecycleCommand Lifecycle { get; init; }

}
