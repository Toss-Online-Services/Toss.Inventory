namespace Toss.Inventory.Domain.Entities.Events;
using Catalog;
using Toss.Inventory.Domain.Entities;

public record class ProductReviewAddedDomainEvent(Product Product, Review Review) : BaseEvent;
