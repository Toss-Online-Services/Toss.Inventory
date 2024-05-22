using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;
public record class ProductRentalDetailsUpdatedEvent(Product Product, int OldRentalPriceLength, int NewRentalPriceLength, int OldRentalPricePeriodId, int NewRentalPricePeriodId):BaseEvent;
