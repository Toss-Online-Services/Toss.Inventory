using Domain.Entities.Catalog;

namespace Domain.Entities.Product.Events;
public record ProductAvailabilityUpdatedDomainEvent(string ProductId, Availability Availability) : BaseEvent;
