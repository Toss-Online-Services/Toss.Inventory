
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;

public record class ProductCreatedDomainEvent(Product product) : BaseEvent;
