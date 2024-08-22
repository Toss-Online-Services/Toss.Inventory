namespace Domain.Entities.Catalog.Events;
public record class ProductDownloadLinkChangedEvent(Product Product, int OldDownloadId, int NewDownloadId) : BaseEvent;
