namespace Domain.Entities.Catalog.Events;

public record class ProductReviewUpdatedDomainEvent(Product Product, Review Review) : BaseEvent;
