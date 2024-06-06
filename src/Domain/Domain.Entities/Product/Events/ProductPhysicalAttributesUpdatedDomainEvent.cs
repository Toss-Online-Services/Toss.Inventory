namespace Domain.Entities.Product.Events;
public record ProductPhysicalAttributesUpdatedDomainEvent(string ProductId, PhysicalAttributes PhysicalAttributes) : BaseEvent;
