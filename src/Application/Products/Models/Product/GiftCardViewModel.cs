namespace Application.Products.Models.Product;
public record GiftCardViewModel(bool IsGiftCard, int GiftCardTypeId, decimal? OverriddenGiftCardAmount){
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GiftCardViewModel, GiftCard>().ReverseMap();
        }
    }
}
