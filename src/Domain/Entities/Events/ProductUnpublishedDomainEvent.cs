namespace Domain.Entities.Events;
public record class ProductUnpublishedDomainEvent(Product product) : BaseEvent;