namespace Domain.Entities.Events;
public record ProductLifecycleUpdatedDomainEvent(Guid ProductId, Lifecycle Lifecycle) : BaseEvent;
