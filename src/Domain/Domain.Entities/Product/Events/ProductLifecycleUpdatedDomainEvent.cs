namespace Domain.Entities.Product.Events;
public record ProductLifecycleUpdatedDomainEvent(string ProductId, Lifecycle Lifecycle) : BaseEvent;
