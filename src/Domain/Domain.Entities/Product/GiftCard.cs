namespace Domain.Entities.Product;
public class GiftCard : ValueObject
{
    public bool IsGiftCard { get; private set; }
    public int GiftCardTypeId { get; private set; }
    public decimal? OverriddenGiftCardAmount { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsGiftCard;
        yield return OverriddenGiftCardAmount;
        yield return GiftCardTypeId;
    }

    internal void Apply(UpdateGiftCardCommand giftCard)
    {
        IsGiftCard = giftCard.IsGiftCard;
        OverriddenGiftCardAmount = giftCard.OverriddenGiftCardAmount;
        GiftCardTypeId = giftCard.GiftCardTypeId;
    }
}

