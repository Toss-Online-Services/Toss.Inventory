namespace Domain.Entities.Catalog.Events;
public record ProductPhysicalAttributesUpdatedDomainEvent(Guid ProductId, PhysicalAttributes PhysicalAttributes) : BaseEvent;
