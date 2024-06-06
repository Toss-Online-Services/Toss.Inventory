namespace Domain.Entities.Product.Events;

public record class ProductReviewAddedDomainEvent(Product Product, Review Review) : BaseEvent;
