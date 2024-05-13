using Domain.Entities.Catalog;

namespace Domain.Entities.Events;

public class ProductActivatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductActivatedDomainEvent(Product product)
    {
        Product = product;
    }
}
