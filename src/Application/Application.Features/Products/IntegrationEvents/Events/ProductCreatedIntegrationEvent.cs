using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;
using Infrastructure.EventBus.Events;

namespace Application.Features.Products.IntegrationEvents.Events;
public record class ProductCreatedIntegrationEvent: IntegrationEvent
{
    public Product Product { get; init; }

    public ProductCreatedIntegrationEvent(Product product)
        => Product = product;
}
