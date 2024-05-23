using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;
public record class ProductRentalDetailsUpdatedEvent(Product Product, int OldRentalPriceLength, int NewRentalPriceLength, int OldRentalPricePeriodId, int NewRentalPricePeriodId):BaseEvent;
