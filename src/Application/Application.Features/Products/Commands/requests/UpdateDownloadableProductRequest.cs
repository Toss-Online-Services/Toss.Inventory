namespace Domain.Entities.Product.Commands;
public record UpdateDownloadableProductRequest : DownloadableProductCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateDownloadableProductRequest, UpdateDownloadableProductCommand>();
        }
    }
}
