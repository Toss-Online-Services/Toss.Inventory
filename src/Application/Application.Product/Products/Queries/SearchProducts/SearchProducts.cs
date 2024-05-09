namespace Application.Product.Products.Queries.SearchProducts;

public record SearchProductsQuery : IRequest<CommandResult<IPagedList<Product>>>
{
}

public class SearchProductsQueryValidator : AbstractValidator<SearchProductsQuery>
{
    public SearchProductsQueryValidator()
    {
    }
}

public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, CommandResult<IPagedList<Product>>>
{
    private readonly IProductRepository _context;

    public SearchProductsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<IPagedList<Product>>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
