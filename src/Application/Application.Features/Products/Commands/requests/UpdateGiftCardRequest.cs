namespace Domain.Entities.Product;
public record UpdateGiftCardRequest : GiftCardCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateGiftCardRequest, UpdateGiftCardCommand>();
        }
    }

}

