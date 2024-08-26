namespace Domain.Entities.Events;
public record ProductAvailabilityUpdatedDomainEvent(Guid ProductId, Availability Availability) : BaseEvent;
