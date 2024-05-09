using Domain.Entities.Products;
using Toss.Inventory.Catalog.Domain.Common;

namespace Domain.Entities.Events;

public class ProductDiscountAppliedDomainEvent : BaseEvent
{
    public Product Product { get; }
    public DiscountProductMapping Discount { get; }

    public ProductDiscountAppliedDomainEvent(Product product, DiscountProductMapping discount)
    {
        Product = product;
        Discount = discount;
    }
}
