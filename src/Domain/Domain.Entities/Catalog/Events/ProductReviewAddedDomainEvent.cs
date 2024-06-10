namespace Domain.Entities.Catalog.Events;
using Catalog;
public record class ProductReviewAddedDomainEvent(Product Product, Review Review) : BaseEvent;
