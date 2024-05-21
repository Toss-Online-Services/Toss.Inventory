using Infrastructure.Data;
using Infrastructure.EventBus.Abstractions;
using Infrastructure.IntegrationEventLogEF.Services;
using Microsoft.Extensions.Logging;

namespace Application.Infrastructure.IntegrationEvents;

public class CatalogIntegrationEventService(IEventBus eventBus,
    CatalogContext CatalogContext,
    IIntegrationEventLogService integrationEventLogService,
    ILogger<CatalogIntegrationEventService> logger) : ICatalogIntegrationEventService
{
    private readonly IEventBus _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
    private readonly CatalogContext _CatalogContext = CatalogContext ?? throw new ArgumentNullException(nameof(CatalogContext));
    private readonly IIntegrationEventLogService _eventLogService = integrationEventLogService ?? throw new ArgumentNullException(nameof(integrationEventLogService));
    private readonly ILogger<CatalogIntegrationEventService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task PublishEventsThroughEventBusAsync(IntegrationEvent evt)
    {
        await PublishEventsThroughEventBusAsync(evt.Id);
    }
    public async Task PublishEventsThroughEventBusAsync(Guid transactionId)
    {
        var pendingLogEvents = await _eventLogService.RetrieveEventLogsPendingToPublishAsync(transactionId);

        foreach (var logEvt in pendingLogEvents)
        {
            _logger.LogInformation("Publishing integration event: {IntegrationEventId} - ({@IntegrationEvent})", logEvt.EventId, logEvt.IntegrationEvent);

            try
            {
                await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                await _eventBus.PublishAsync(logEvt.IntegrationEvent);
                await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing integration event: {IntegrationEventId}", logEvt.EventId);

                await _eventLogService.MarkEventAsFailedAsync(logEvt.EventId);
            }
        }
    }

    public async Task AddAndSaveEventAsync(IntegrationEvent evt)
    {
        _logger.LogInformation("Enqueuing integration event {IntegrationEventId} to repository ({@IntegrationEvent})", evt.Id, evt);

        await _eventLogService.SaveEventAsync(evt, _CatalogContext.GetCurrentTransaction());
    }
}
