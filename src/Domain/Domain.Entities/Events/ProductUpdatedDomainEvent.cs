using Domain.Entities.Products;
using Toss.Inventory.Catalog.Domain.Common;

namespace Domain.Entities.Events;

public class ProductUpdatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductUpdatedDomainEvent(Product product)
    {
        Product = product;
    }
}
