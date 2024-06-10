namespace Domain.Entities.Product.Events;
using Domain.Entities.Catalog;
public record class ProductDeletedDomainEvent(Product product) : BaseEvent;
