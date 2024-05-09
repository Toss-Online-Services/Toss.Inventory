namespace Application.Product.Products.Queries.GetAssociatedProducts;

public record GetAssociatedProductsQuery : IRequest<CommandResult<List<Product>>>
{
}

public class GetAssociatedProductsQueryValidator : AbstractValidator<GetAssociatedProductsQuery>
{
    public GetAssociatedProductsQueryValidator()
    {
    }
}

public class GetAssociatedProductsQueryHandler : IRequestHandler<GetAssociatedProductsQuery, CommandResult<List<Product>>>
{
    private readonly IProductRepository _context;

    public GetAssociatedProductsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<Product>>> Handle(GetAssociatedProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
