using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;
public record ProductRecurringDetailsUpdatedEvent(Product Product, int OldCycleLength, int NewCycleLength, int OldCyclePeriodId, int NewCyclePeriodId, int OldTotalCycles, int NewTotalCycles) : BaseEvent;
