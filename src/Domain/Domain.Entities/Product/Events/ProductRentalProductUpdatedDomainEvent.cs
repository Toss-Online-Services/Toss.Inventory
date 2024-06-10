using Domain.Entities.Catalog;

namespace Domain.Entities.Product.Events;
public record RentalProductUpdatedDomainEvent(string ProductId, RentalProduct RentalProduct) : BaseEvent;
