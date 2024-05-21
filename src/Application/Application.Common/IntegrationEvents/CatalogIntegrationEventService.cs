using Infrastructure.Data;
using Infrastructure.Data.Data;
using Infrastructure.EventBus.Abstractions;
using Infrastructure.IntegrationEventLogEF.Services;
using Infrastructure.IntegrationEventLogEF.Utilities;
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
    private volatile bool disposedValue;
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
        logger.LogInformation("CatalogIntegrationEventService - Saving changes and integrationEvent: {IntegrationEventId}", evt.Id);

        //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
        //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
        await ResilientTransaction.New(_CatalogContext).ExecuteAsync(async () =>
        {
            // Achieving atomicity between original catalog database operation and the IntegrationEventLog thanks to a local transaction
            await _CatalogContext.SaveChangesAsync();
            await integrationEventLogService.SaveEventAsync(evt, _CatalogContext.Database.CurrentTransaction);
        });
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                (integrationEventLogService as IDisposable)?.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
