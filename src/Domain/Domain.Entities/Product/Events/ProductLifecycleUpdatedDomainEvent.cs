using Domain.Entities.Catalog;

namespace Domain.Entities.Product.Events;
public record ProductLifecycleUpdatedDomainEvent(string ProductId, Lifecycle Lifecycle) : BaseEvent;
