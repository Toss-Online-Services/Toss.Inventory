namespace Application.Products.Commands.Requests;
public record UpdateGiftCardRequest : GiftCardCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateGiftCardRequest, UpdateGiftCardCommand>();
        }
    }

}
