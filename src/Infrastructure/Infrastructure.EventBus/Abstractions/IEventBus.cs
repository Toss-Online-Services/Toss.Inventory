using Infrastructure.EventBus.Events;

namespace Infrastructure.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event);
}
