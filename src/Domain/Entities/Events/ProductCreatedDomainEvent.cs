namespace Domain.Entities.Events;
public record class ProductCreatedDomainEvent(Product product) : BaseEvent;
