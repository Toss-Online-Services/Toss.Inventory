using Domain.Infrastructure;

namespace Domain.Entities.Catalog.Events;

public record class ProductCreatedDomainEvent(Product product) : BaseEvent;
