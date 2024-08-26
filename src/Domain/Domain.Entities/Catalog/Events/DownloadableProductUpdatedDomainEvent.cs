namespace Domain.Entities.Catalog.Events;
public record DownloadableProductUpdatedDomainEvent(Guid ProductId, DownloadableProduct GiftCard) : BaseEvent;
