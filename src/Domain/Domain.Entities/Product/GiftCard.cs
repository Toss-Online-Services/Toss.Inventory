using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class GiftCard : ValueObject
{
    public bool IsGiftCard { get; set; }
    public int GiftCardTypeId { get; set; }
    public decimal? OverriddenGiftCardAmount { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsGiftCard;
        yield return OverriddenGiftCardAmount;
        yield return GiftCardTypeId;
    }
}

