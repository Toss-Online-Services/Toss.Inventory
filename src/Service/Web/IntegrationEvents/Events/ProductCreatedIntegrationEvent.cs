using Domain.Entities.Catalog;
using Infrastructure.EventBus.Events;

namespace Web.IntegrationEvents.Events;
public record class ProductCreatedIntegrationEvent : IntegrationEvent
{
    public Product Product { get; init; }

    public ProductCreatedIntegrationEvent(Product product)
        => Product = product;
}
