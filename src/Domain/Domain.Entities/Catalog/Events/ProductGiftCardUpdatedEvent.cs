namespace Domain.Entities.Catalog.Events;

public record class ProductGiftCardUpdatedEvent(Catalog.Product Product, decimal? OldAmount, decimal? NewAmount) : BaseEvent;
