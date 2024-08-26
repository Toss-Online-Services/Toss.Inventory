namespace Toss.Inventory.Domain.Entities.Events;
public record ProductShippingUpdatedDomainEvent(Guid ProductId, Shipping Shipping) : BaseEvent;
