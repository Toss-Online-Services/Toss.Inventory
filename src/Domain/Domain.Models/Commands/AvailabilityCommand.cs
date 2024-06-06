namespace Domain.Models.Commands;

public record AvailabilityCommand
{
    public DateTime? AvailableStartDateTimeUtc { get; init; }
    public DateTime? AvailableEndDateTimeUtc { get; init; }
    public bool AvailableForPreOrder { get; init; }
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; init; }
    public int ProductAvailabilityRangeId { get; init; }
    public int DeliveryDateId { get; init; }

}
