
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;

public record class ProductReviewDeletedDomainEvent(Product Product, Review Review) : BaseEvent;
