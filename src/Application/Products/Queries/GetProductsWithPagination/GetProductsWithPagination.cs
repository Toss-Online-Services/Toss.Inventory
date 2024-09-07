using Application.Extensions;
using Application.Products.Models.Product;
using Domain.Entities;

namespace Application.Products.Queries.GetProductsWithPagination;

public record GetProductsWithPaginationQuery : IRequest<PaginatedList<ProductViewModel>>
{   
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<ProductViewModel>>
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

    public async Task<PaginatedList<ProductViewModel>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        // Await the task to get the IList<Product>
        IQueryable<Product> products =  _productRepository.GetAllAsync(); // Assuming this returns Task<IList<Product>>
             

        // Apply ProjectTo on the IQueryable<Product>
        var paginatedList = await products
            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedList;
    }
}
