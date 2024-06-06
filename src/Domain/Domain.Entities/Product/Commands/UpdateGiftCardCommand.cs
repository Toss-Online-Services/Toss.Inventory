namespace Domain.Entities.Product;
public record UpdateGiftCardCommand : ICommand<bool>
{
    public bool IsGiftCard { get; init; }
    public int GiftCardTypeId { get; init; }
    public decimal? OverriddenGiftCardAmount { get; init; }

}

