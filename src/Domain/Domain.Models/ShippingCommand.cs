namespace Domain.Models;

public record ShippingCommand()
{
    public bool IsShipEnabled { get; init; }
    public bool IsFreeShipping { get; init; }
    public bool ShipSeparately { get; init; }
    public decimal AdditionalShippingCharge { get; init; }
}

