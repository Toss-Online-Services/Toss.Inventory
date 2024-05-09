namespace Application.Product.Products.Queries.GetLowStockProducts;

public record GetLowStockProductsQuery : IRequest<CommandResult<IPagedList<Product>>>
{
}

public class GetLowStockProductsQueryValidator : AbstractValidator<GetLowStockProductsQuery>
{
    public GetLowStockProductsQueryValidator()
    {
    }
}

public class GetLowStockProductsQueryHandler : IRequestHandler<GetLowStockProductsQuery, CommandResult<IPagedList<Product>>>
{
    private readonly IProductRepository _context;

    public GetLowStockProductsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<IPagedList<Product>>> Handle(GetLowStockProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
