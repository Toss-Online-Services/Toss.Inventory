using Domain.Entities.Product;
using Infrastructure.EventBus.Events;

namespace Application.Features.Products.IntegrationEvents.Events;
public record class ProductCreatedIntegrationEvent: IntegrationEvent
{
    public Product Product { get; init; }

    public ProductCreatedIntegrationEvent(Product product)
        => Product = product;
}
