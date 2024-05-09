using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities.Events;

public class ProductActivatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductActivatedDomainEvent(Product product)
    {
        Product = product;
    }
}
