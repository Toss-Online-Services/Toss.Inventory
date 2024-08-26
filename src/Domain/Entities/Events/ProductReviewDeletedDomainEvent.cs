namespace Domain.Entities.Events;

public record class ProductReviewDeletedDomainEvent(Product Product, Review Review) : BaseEvent;
