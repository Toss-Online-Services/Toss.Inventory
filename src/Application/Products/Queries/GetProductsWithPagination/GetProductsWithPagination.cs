using Application.Extensions;
using Application.Products.Models;
using Domain.Entities;

namespace Application.Products.Queries.GetProductsWithPagination;

public record GetProductsWithPaginationQuery : IRequest<PaginatedList<ProductModel>>
{   
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<ProductModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<GetProductsWithPaginationQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetProductsWithPaginationQueryHandler(
        IProductRepository productRepository,
        ILogger<GetProductsWithPaginationQueryHandler> logger,
        IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductModel>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        // Await the task to get the IList<Product>
        List<Product> products = await _productRepository.GetAllAsync(); // Assuming this returns Task<IList<Product>>

        // Convert the IList<Product> to IQueryable<Product>
        var queryableProducts = products.AsQueryable();

        // Apply ProjectTo on the IQueryable<Product>
        var paginatedList = await queryableProducts
            .ProjectTo<ProductModel>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedList;
    }
}
