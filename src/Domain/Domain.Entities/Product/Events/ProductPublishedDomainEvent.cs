namespace Domain.Entities.Product.Events;
using Domain.Entities.Catalog;

public record class ProductPublishedDomainEvent(Product product) : BaseEvent;
