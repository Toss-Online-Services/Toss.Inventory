using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;
public record ProductAvailabilityChangedEvent(Product Product, bool OldAvailability, bool NewAvailability) : BaseEvent;
