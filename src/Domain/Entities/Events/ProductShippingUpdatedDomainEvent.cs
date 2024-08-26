namespace Domain.Entities.Events;
public record ProductShippingUpdatedDomainEvent(Guid ProductId, Shipping Shipping) : BaseEvent;
