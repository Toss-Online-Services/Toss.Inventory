using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class RecurringProduct:Entity
{
    public bool IsRecurring { get; set; }
    public int RecurringCycleLength { get; set; }
    public int RecurringCyclePeriodId { get; set; }
    public int RecurringTotalCycles { get; set; }
}

