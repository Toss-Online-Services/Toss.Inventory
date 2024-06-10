namespace Domain.Entities.Catalog.Events;
public record ProductGiftCardUpdatedDomainEvent(string ProductId, GiftCard GiftCard) : BaseEvent;
