using Domain.Entities.Products;
using Toss.Inventory.Catalog.Domain.Common;

namespace Domain.Entities.Events;

public class ProductCreatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductCreatedDomainEvent(Product product)
    {
        Product = product;
    }
}
