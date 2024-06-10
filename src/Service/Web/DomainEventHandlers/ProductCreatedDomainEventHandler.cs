using Application.Events.IntegrationEvents;
using Domain.Repositories;
using Application.Infrastructure.Extensions;
using Web.IntegrationEvents.Events;
using Domain.Entities.Catalog.Events;

namespace Web.DomainEventHandlers;
public class ProductCreatedDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
{
    private readonly ILogger _logger;
    private readonly IProductRepository _productRepository;
    private readonly ICatalogIntegrationEventService _catalogIntegrationEventService;

    public ProductCreatedDomainEventHandler(
        ILogger<ProductCreatedDomainEventHandler> logger,
        IProductRepository productRepository,
        ICatalogIntegrationEventService catalogIntegrationEventService)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _catalogIntegrationEventService = catalogIntegrationEventService ?? throw new ArgumentNullException(nameof(catalogIntegrationEventService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        ApiTrace.LogProductCreated(_logger, notification.product.Id);

        var integrationEvent = new ProductCreatedIntegrationEvent(notification.product);
        await _catalogIntegrationEventService.AddAndSaveEventAsync(integrationEvent);
        await _catalogIntegrationEventService.PublishThroughEventBusAsync(integrationEvent);
    }
}
