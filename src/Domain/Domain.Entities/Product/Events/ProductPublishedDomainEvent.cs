
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;

public record class ProductPublishedDomainEvent(Product product) : BaseEvent;
