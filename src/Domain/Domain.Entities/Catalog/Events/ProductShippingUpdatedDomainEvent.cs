namespace Domain.Entities.Catalog.Events;
public record ProductShippingUpdatedDomainEvent(Guid ProductId, Shipping Shipping) : BaseEvent;
