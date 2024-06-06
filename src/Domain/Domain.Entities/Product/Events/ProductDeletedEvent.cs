namespace Domain.Entities.Product.Events;

public record class ProductDeletedEvent(Product product) : BaseEvent;
