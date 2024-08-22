namespace Domain.Entities.Catalog.Events;
public record class ProductPublishedDomainEvent(Product product) : BaseEvent;
