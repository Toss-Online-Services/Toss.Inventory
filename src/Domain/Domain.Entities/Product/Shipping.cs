using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Shipping:Entity
{
    public bool IsShipEnabled { get; set; }
    public bool IsFreeShipping { get; set; }
    public bool ShipSeparately { get; set; }
    public decimal AdditionalShippingCharge { get; set; }
}

