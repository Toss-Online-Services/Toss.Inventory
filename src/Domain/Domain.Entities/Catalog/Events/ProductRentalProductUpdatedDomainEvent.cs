namespace Domain.Entities.Catalog.Events;
public record RentalProductUpdatedDomainEvent(Guid ProductId, RentalProduct RentalProduct) : BaseEvent;
