namespace Domain.Entities.Events;
public record class ProductPublishedDomainEvent(Product product) : BaseEvent;
