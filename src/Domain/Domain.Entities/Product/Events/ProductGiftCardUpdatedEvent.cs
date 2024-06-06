namespace Domain.Entities.Product.Events;

public record class ProductGiftCardUpdatedEvent(Product Product, decimal? OldAmount, decimal? NewAmount) : BaseEvent;
