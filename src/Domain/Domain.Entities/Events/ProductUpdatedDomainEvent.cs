using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities.Events;

public class ProductUpdatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductUpdatedDomainEvent(Product product)
    {
        Product = product;
    }
}
