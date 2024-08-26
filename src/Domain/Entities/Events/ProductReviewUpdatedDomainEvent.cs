namespace Domain.Entities.Events;

public record class ProductReviewUpdatedDomainEvent(Product Product, Review Review) : BaseEvent;
