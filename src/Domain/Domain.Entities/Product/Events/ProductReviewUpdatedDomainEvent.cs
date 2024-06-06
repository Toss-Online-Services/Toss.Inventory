namespace Domain.Entities.Product.Events;

public record class ProductReviewUpdatedDomainEvent(Product Product, Review Review) : BaseEvent;
