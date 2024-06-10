namespace Domain.Entities.Catalog.Events;

public record class ProductReviewDeletedDomainEvent(Product Product, Review Review) : BaseEvent;
