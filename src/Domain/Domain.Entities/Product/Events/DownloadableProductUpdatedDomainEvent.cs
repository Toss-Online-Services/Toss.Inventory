namespace Domain.Entities.Product.Events;
public record DownloadableProductUpdatedDomainEvent(string ProductId, DownloadableProduct GiftCard) : BaseEvent;
