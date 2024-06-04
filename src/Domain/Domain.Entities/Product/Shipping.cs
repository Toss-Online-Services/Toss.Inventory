using Domain.Entities.Product.Commands;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Shipping : ValueObject
{
    public bool IsShipEnabled { get; private set; }
    public bool IsFreeShipping { get; private set; }
    public bool ShipSeparately { get; private set; }
    public decimal AdditionalShippingCharge { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsShipEnabled;
        yield return IsFreeShipping;
        yield return ShipSeparately;
        yield return AdditionalShippingCharge;
    }

    internal void Apply(UpdateShippingCommand shipping)
    {
        IsShipEnabled = shipping.IsShipEnabled;
        IsFreeShipping = shipping.IsFreeShipping;
        ShipSeparately = shipping.ShipSeparately;
        AdditionalShippingCharge = shipping.AdditionalShippingCharge;
    }
}

