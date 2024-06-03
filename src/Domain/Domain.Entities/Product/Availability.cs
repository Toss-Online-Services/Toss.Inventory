using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Availability : ValueObject
{
    public DateTime? AvailableStartDateTimeUtc { get; private set; }
    public DateTime? AvailableEndDateTimeUtc { get; private set; }
    public bool AvailableForPreOrder { get; private set; }
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; private set; }
    public int ProductAvailabilityRangeId { get; private set; }
    public int DeliveryDateId { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AvailableEndDateTimeUtc;
        yield return AvailableForPreOrder;
        yield return PreOrderAvailabilityStartDateTimeUtc;
        yield return ProductAvailabilityRangeId;
        yield return DeliveryDateId;
    }
}

