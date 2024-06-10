namespace Domain.Entities.Catalog.Events;

public record ProductReviewedEvent(Product Product, int Rating, string Review) : BaseEvent;
