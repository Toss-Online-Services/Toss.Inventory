namespace Domain.Entities.Events;

public record ProductReviewedEvent(Product Product, int Rating, string Review) : BaseEvent;
