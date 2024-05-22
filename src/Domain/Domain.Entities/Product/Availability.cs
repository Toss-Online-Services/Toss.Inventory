using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Availability : ValueObject
{
    public DateTime? AvailableStartDateTimeUtc { get; set; }
    public DateTime? AvailableEndDateTimeUtc { get; set; }
    public bool AvailableForPreOrder { get; set; }
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
    public int ProductAvailabilityRangeId { get; set; }
    public int DeliveryDateId { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AvailableEndDateTimeUtc;
        yield return AvailableForPreOrder;
        yield return PreOrderAvailabilityStartDateTimeUtc;
        yield return ProductAvailabilityRangeId;
        yield return DeliveryDateId;
    }
}

