namespace Application.Products.Commands.Requests;
public record UpdateDownloadableProductRequest : DownloadableProductCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateDownloadableProductRequest, UpdateDownloadableProductCommand>();
        }
    }
}
