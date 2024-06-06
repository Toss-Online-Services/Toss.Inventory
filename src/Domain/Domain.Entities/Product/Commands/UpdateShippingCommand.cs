namespace Domain.Entities.Product.Commands;

public record UpdateShippingCommand() : ICommand<bool>
{
    public bool IsShipEnabled { get; init; }
    public bool IsFreeShipping { get; init; }
    public bool ShipSeparately { get; init; }
    public decimal AdditionalShippingCharge { get; init; }
}

