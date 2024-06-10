using Domain.Entities.Catalog;

namespace Domain.Entities.Product.Events;
public record ProductShippingUpdatedDomainEvent(string ProductId, Shipping Shipping) : BaseEvent;
