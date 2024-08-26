namespace Domain.Entities.Events;
public record class ProductReviewAddedDomainEvent(Product Product, Review Review) : BaseEvent;
