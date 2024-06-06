namespace Domain.Entities.Product.Events;
public record ProductReviewedEvent(Product Product, int Rating, string Review) : BaseEvent;
