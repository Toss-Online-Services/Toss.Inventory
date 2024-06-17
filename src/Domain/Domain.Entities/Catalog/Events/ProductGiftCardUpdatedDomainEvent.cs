namespace Domain.Entities.Catalog.Events;
public record ProductGiftCardUpdatedDomainEvent(Guid ProductId, GiftCard GiftCard) : BaseEvent;
