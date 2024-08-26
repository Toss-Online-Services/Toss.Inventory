namespace Domain.Entities.Catalog.Events;
public record class ProductRentalDetailsUpdatedEvent(Product Product, int OldRentalPriceLength, int NewRentalPriceLength, int OldRentalPricePeriodId, int NewRentalPricePeriodId) : BaseEvent;
