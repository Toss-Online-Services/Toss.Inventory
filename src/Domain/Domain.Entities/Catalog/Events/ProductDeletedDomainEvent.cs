namespace Domain.Entities.Catalog.Events;
public record class ProductDeletedDomainEvent(Product product) : BaseEvent;
