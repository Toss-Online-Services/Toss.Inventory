using Application.Infrastructure.IntegrationEvents;
using Application.Infrastructure.Interfaces;
using AutoMapper;
using Domain.Entities.Product.Commands;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Product.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly IIdentityService _identityService;
    private readonly IMediator _mediator;
    private readonly ICatalogIntegrationEventService _integrationEventService;
    private readonly ILogger<CreateProductCommandHandler> _logger;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IMediator mediator,
        ICatalogIntegrationEventService integrationEventService,
        IProductRepository productRepository,
        IIdentityService identityService,
        ILogger<CreateProductCommandHandler> logger,
        IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _integrationEventService = integrationEventService ?? throw new ArgumentNullException(nameof(integrationEventService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating Order - Order: {@Order}", request);
        _productRepository.Add(new Domain.Entities.Product.Product(_mapper.Map<CreateProductCommand>(request)));
        return await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
