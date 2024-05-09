using Domain.Entities.Products;
using Toss.Inventory.Catalog.Domain.Common;

namespace Domain.Entities.Events;

public class ProductActivatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductActivatedDomainEvent(Product product)
    {
        Product = product;
    }
}
