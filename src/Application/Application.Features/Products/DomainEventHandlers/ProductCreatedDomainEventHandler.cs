using Application.Events.IntegrationEvents;
using Application.Features.Products.IntegrationEvents.Events;
using Domain.Entities.Product.Events;
using Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Features.Products.DomainEventHandlers;
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
    }
}
