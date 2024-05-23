using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Price : ValueObject
{
    public decimal CurrentPrice { get; set; }
    public decimal OldPrice { get; set; }
    public decimal ProductCost { get; set; }
    public bool CustomerEntersPrice { get; set; }
    public decimal MinimumCustomerEnteredPrice { get; set; }
    public decimal MaximumCustomerEnteredPrice { get; set; }
    public bool BasepriceEnabled { get; set; }
    public decimal BasepriceAmount { get; set; }
    public int BasepriceUnitId { get; set; }
    public decimal BasepriceBaseAmount { get; set; }
    public int BasepriceBaseUnitId { get; set; }
    public bool CallForPrice { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return CurrentPrice;
        yield return OldPrice;
        yield return ProductCost;
        yield return MinimumCustomerEnteredPrice;
        yield return MaximumCustomerEnteredPrice;
        yield return BasepriceAmount;
        yield return BasepriceBaseUnitId;
        yield return CallForPrice;
        yield return ProductCost;
        yield return MinimumCustomerEnteredPrice;
        yield return MaximumCustomerEnteredPrice;
        yield return BasepriceAmount;

    }
}

