namespace Domain.Entities.Events;
public record ProductPictureAddedDomainEvent : BaseEvent
{
    public Product Product { get; }
    public ProductPicture Picture { get; }

    public ProductPictureAddedDomainEvent(Product product, ProductPicture picture)
    {
        Product = product;
        Picture = picture;
    }
}
