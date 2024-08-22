using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EventBus.Abstractions;

public interface IEventBusBuilder
{
    public IServiceCollection Services { get; }
}
