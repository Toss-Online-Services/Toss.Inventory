namespace Domain.Entities.Catalog.Events;
public record ProductAvailabilityUpdatedDomainEvent(string ProductId, Availability Availability) : BaseEvent;
