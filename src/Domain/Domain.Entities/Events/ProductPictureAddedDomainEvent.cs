using Domain.Entities.Products;
using Toss.Inventory.Catalog.Domain.Common;

namespace Domain.Entities.Events;

public class ProductPictureAddedDomainEvent : BaseEvent
{
    public Product Product { get; }
    public ProductPicture Picture { get; }

    public ProductPictureAddedDomainEvent(Product product, ProductPicture picture)
    {
        Product = product;
        Picture = picture;
    }
}
