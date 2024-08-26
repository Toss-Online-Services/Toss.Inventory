namespace Domain.Entities.Catalog.Events;

public record class ProductUpdatedDomainEvent(Product product) : BaseEvent;
