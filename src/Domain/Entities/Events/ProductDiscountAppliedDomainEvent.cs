using Domain.Entities.Discounts;

namespace Toss.Inventory.Domain.Entities.Events;

public record ProductDiscountAppliedDomainEvent : BaseEvent
{
    public Product Product { get; }
    public DiscountProductMapping Discount { get; }

    public ProductDiscountAppliedDomainEvent(Product product, DiscountProductMapping discount)
    {
        Product = product;
        Discount = discount;
    }
}
