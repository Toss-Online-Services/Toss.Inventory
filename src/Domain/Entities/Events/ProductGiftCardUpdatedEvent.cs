namespace Domain.Entities.Events;

public record class ProductGiftCardUpdatedEvent(Product Product, decimal? OldAmount, decimal? NewAmount) : BaseEvent;
