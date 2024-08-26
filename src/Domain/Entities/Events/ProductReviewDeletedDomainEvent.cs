namespace Toss.Inventory.Domain.Entities.Events;

public record class ProductReviewDeletedDomainEvent(Product Product, Review Review) : BaseEvent;
