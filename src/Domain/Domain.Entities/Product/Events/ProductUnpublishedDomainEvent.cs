namespace Domain.Entities.Product.Events;

public record class ProductUnpublishedDomainEvent(Product product) : BaseEvent;
