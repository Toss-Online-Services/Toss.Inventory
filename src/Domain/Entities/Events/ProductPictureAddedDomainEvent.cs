namespace Toss.Inventory.Domain.Entities.Events;
using Catalog;
using Toss.Inventory.Domain.Entities;

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
