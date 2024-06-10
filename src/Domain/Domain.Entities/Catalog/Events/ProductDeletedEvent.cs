namespace Domain.Entities.Catalog.Events;

public record class ProductDeletedEvent(Product product) : BaseEvent;
