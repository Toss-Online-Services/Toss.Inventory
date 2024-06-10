using Domain.Entities.Catalog;

namespace Domain.Entities.Product.Events;

public record class ProductReviewDeletedDomainEvent(Product Product, Review Review) : BaseEvent;
