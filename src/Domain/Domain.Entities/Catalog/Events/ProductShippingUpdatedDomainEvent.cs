namespace Domain.Entities.Catalog.Events;
public record ProductShippingUpdatedDomainEvent(string ProductId, Shipping Shipping) : BaseEvent;
