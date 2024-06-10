namespace Domain.Entities.Catalog.Events;
public record DownloadableProductUpdatedDomainEvent(string ProductId, DownloadableProduct GiftCard) : BaseEvent;
