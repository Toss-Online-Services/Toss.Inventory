namespace Application.Product.Products.Queries.GetAllProductsDisplayedOnHomepage;

public record GetAllProductsDisplayedOnHomepageQuery : IRequest<CommandResult<List<Product>>>
{
}

public class GetAllProductsDisplayedOnHomepageQueryValidator : AbstractValidator<GetAllProductsDisplayedOnHomepageQuery>
{
    public GetAllProductsDisplayedOnHomepageQueryValidator()
    {
    }
}

public class GetAllProductsDisplayedOnHomepageQueryHandler : IRequestHandler<GetAllProductsDisplayedOnHomepageQuery, CommandResult<List<Product>>>
{
    private readonly IProductRepository _context;

    public GetAllProductsDisplayedOnHomepageQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<Product>>> Handle(GetAllProductsDisplayedOnHomepageQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
