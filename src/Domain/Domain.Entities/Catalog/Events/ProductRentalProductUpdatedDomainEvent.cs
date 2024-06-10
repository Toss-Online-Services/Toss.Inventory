namespace Domain.Entities.Catalog.Events;
public record RentalProductUpdatedDomainEvent(string ProductId, RentalProduct RentalProduct) : BaseEvent;
