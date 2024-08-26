namespace Domain.Entities.Events;
public record DownloadableProductUpdatedDomainEvent(Guid ProductId, DownloadableProduct GiftCard) : BaseEvent;
