namespace Domain.Entities.Catalog.Events;
public record class ProductUnpublishedDomainEvent(Product product) : BaseEvent;
