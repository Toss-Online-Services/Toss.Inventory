using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Price:Entity
{
    public decimal CurrentPrice { get; set; }
    public decimal OldPrice { get; set; }
    public decimal ProductCost { get; set; }
    public bool CustomerEntersPrice { get; set; }
    public decimal MinimumCustomerEnteredPrice { get; set; }
    public decimal MaximumCustomerEnteredPrice { get; set; }
    public bool BasepriceEnabled { get; set; }
    public decimal BasepriceAmount { get; set; }
    public int BasepriceUnitId { get; set; }
    public decimal BasepriceBaseAmount { get; set; }
    public int BasepriceBaseUnitId { get; set; }
    public bool CallForPrice { get; set; }
}

