namespace Domain.Entities.Events;
public record class ProductDeletedDomainEvent(Product product) : BaseEvent;
