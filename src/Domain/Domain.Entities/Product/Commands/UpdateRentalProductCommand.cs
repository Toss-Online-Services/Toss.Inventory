using Domain.Infrastructure;

namespace Domain.Entities.Product;
public record UpdateRentalProductCommand : ICommand<bool>
{
    public bool IsRental { get; init; }
    public int RentalPriceLength { get; init; }
    public int RentalPricePeriodId { get; init; }
}
