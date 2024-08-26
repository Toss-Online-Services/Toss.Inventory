namespace Toss.Inventory.Domain.Entities.Events;
public record ProductPhysicalAttributesUpdatedDomainEvent(Guid ProductId, PhysicalAttributes PhysicalAttributes) : BaseEvent;
