using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class RentalProduct : ValueObject
{
    public bool IsRental { get; private set; }
    public int RentalPriceLength { get; private set; }
    public int RentalPricePeriodId { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsRental;
        yield return RentalPriceLength;
        yield return RentalPricePeriodId;
    }

    internal void Apply(UpdateRentalProductCommand rentalProduct)
    {
        IsRental = rentalProduct.IsRental;
        RentalPriceLength = rentalProduct.RentalPriceLength;
        RentalPricePeriodId = rentalProduct.RentalPricePeriodId;
    }
}
