namespace Domain.Entities.Catalog.Events;
public record ProductLifecycleUpdatedDomainEvent(Guid ProductId, Lifecycle Lifecycle) : BaseEvent;
