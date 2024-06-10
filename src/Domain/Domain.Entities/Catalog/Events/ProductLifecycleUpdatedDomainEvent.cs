namespace Domain.Entities.Catalog.Events;
public record ProductLifecycleUpdatedDomainEvent(string ProductId, Lifecycle Lifecycle) : BaseEvent;
