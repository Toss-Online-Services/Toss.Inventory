using Domain.Entities.Product.Commands;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public record UpdateGiftCardRequest : IRequest<bool>
{
    public bool IsGiftCard { get; init; }
    public int GiftCardTypeId { get; init; }
    public decimal? OverriddenGiftCardAmount { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateGiftCardRequest, UpdateGiftCardCommand>();
        }
    }

}

