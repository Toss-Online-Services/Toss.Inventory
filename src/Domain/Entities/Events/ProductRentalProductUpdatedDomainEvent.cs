namespace Toss.Inventory.Domain.Entities.Events;
public record RentalProductUpdatedDomainEvent(Guid ProductId, RentalProduct RentalProduct) : BaseEvent;
