
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;

public record class ProductDeletedDomainEvent(Product product) : BaseEvent;
