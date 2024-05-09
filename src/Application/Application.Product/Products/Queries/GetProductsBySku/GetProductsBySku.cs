namespace Application.Product.Products.Queries.GetProductsBySku;

public record GetProductsBySkuQuery : IRequest<CommandResult<List<Product>>>
{
}

public class GetProductsBySkuQueryValidator : AbstractValidator<GetProductsBySkuQuery>
{
    public GetProductsBySkuQueryValidator()
    {
    }
}

public class GetProductsBySkuQueryHandler : IRequestHandler<GetProductsBySkuQuery, CommandResult<List<Product>>>
{
    private readonly IProductRepository _context;

    public GetProductsBySkuQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<Product>>> Handle(GetProductsBySkuQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
