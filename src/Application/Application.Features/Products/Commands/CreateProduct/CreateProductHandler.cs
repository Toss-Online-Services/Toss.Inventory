using Application.Infrastructure.IntegrationEvents;
using Application.Infrastructure.Services;
using Domain.Entities.Product.Commands;
using Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, int>
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;
    private readonly ILogger<CreateProductCommandHandler> _logger;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IMediator mediator,
        IProductRepository productRepository,
        ILogger<CreateProductCommandHandler> logger,
        IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        //_integrationEventService = integrationEventService ?? throw new ArgumentNullException(nameof(integrationEventService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating Order - Order: {@Order}", request);
        int res = 0;
        try
        {
            var comm = _mapper.Map<CreateProductCommand>(request);
            var p = new Domain.Entities.Product.Product(comm);

            _productRepository.Add(p);
            res = await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            throw;
        }
        

        return res;
    }
}
