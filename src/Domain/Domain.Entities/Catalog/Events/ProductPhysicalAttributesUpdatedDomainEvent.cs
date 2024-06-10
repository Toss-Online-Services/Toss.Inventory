namespace Domain.Entities.Catalog.Events;
public record ProductPhysicalAttributesUpdatedDomainEvent(string ProductId, PhysicalAttributes PhysicalAttributes) : BaseEvent;
