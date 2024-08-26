namespace Toss.Inventory.Domain.Entities.Events;

public record class ProductReviewUpdatedDomainEvent(Product Product, Review Review) : BaseEvent;
