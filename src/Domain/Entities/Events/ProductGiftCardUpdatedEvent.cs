namespace Toss.Inventory.Domain.Entities.Events;

public record class ProductGiftCardUpdatedEvent(Catalog.Product Product, decimal? OldAmount, decimal? NewAmount) : BaseEvent;
