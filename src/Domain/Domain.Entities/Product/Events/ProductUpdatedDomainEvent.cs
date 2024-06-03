
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;

public record class ProductUpdatedDomainEvent(Product product) : BaseEvent;
