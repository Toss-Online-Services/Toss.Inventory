namespace Domain.Entities.Product.Events;
using Domain.Entities.Catalog;

public record class ProductCreatedDomainEvent(Product product) : BaseEvent;
