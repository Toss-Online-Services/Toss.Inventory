namespace Domain.Entities.Catalog.Events;
public record ProductAvailabilityUpdatedDomainEvent(Guid ProductId, Availability Availability) : BaseEvent;
