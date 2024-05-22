using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Availability: Entity
{
    public DateTime? AvailableStartDateTimeUtc { get; set; }
    public DateTime? AvailableEndDateTimeUtc { get; set; }
    public bool AvailableForPreOrder { get; set; }
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
    public int ProductAvailabilityRangeId { get; set; }
    public int DeliveryDateId { get; set; }
}

