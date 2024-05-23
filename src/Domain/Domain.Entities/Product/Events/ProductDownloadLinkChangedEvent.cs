using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;
public record class ProductDownloadLinkChangedEvent(Product Product, int OldDownloadId, int NewDownloadId):BaseEvent;
