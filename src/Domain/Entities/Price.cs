namespace Toss.Inventory.Domain.Entities;
public class Price : ValueObject
{
    public decimal CurrentPrice { get; private set; }
    public decimal OldPrice { get; private set; }
    public decimal ProductCost { get; private set; }
    public bool CustomerEntersPrice { get; private set; }
    public decimal MinimumCustomerEnteredPrice { get; private set; }
    public decimal MaximumCustomerEnteredPrice { get; private set; }
    public bool BasepriceEnabled { get; private set; }
    public decimal BasepriceAmount { get; private set; }
    public int BasepriceUnitId { get; private set; }
    public decimal BasepriceBaseAmount { get; private set; }
    public int BasepriceBaseUnitId { get; private set; }
    public bool CallForPrice { get; private set; }

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

    internal void Apply(UpdatePriceCommand priceCommand)
    {
        CurrentPrice = priceCommand.Price;
        OldPrice = priceCommand.OldPrice;
        ProductCost = priceCommand.ProductCost;
        CustomerEntersPrice = priceCommand.CustomerEntersPrice;
        MinimumCustomerEnteredPrice = priceCommand.MinimumCustomerEnteredPrice;
        MaximumCustomerEnteredPrice = priceCommand.MaximumCustomerEnteredPrice;
        BasepriceEnabled = priceCommand.BasepriceEnabled;
        BasepriceAmount = priceCommand.BasepriceAmount;
        BasepriceUnitId = priceCommand.BasepriceUnitId;
        BasepriceBaseAmount = priceCommand.BasepriceBaseAmount;
        BasepriceBaseUnitId = priceCommand.BasepriceBaseUnitId;
        CallForPrice = priceCommand.CallForPrice;
    }
}

