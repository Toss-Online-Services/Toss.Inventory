namespace Domain.Commands;
public record RentalProductCommand
{
    public bool IsRental { get; init; }
    public int RentalPriceLength { get; init; }
    public int RentalPricePeriodId { get; init; }
}
