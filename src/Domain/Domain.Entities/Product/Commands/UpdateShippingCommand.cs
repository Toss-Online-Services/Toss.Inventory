using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product.Commands;

public record UpdateShippingCommand() : ICommand<bool>
{
    public bool IsShipEnabled { get; init; }
    public bool IsFreeShipping { get; init; }
    public bool ShipSeparately { get; init; }
    public decimal AdditionalShippingCharge { get; init; }
}

