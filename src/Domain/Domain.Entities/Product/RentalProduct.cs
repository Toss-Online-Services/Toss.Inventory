using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class RentalProduct:Entity
{
    public bool IsRental { get; set; }
    public int RentalPriceLength { get; set; }
    public int RentalPricePeriodId { get; set; }
}
