namespace Domain.Entities.Product.Events;
using Domain.Entities.Catalog;

public record class ProductUnpublishedDomainEvent(Product product) : BaseEvent;
