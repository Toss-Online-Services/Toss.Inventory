namespace Application.Product.Products.Queries.GetCategoryFeaturedProducts;

public record GetCategoryFeaturedProductsQuery : IRequest<CommandResult<List<Product>>>
{
}

public class GetCategoryFeaturedProductsQueryValidator : AbstractValidator<GetCategoryFeaturedProductsQuery>
{
    public GetCategoryFeaturedProductsQueryValidator()
    {
    }
}

public class GetCategoryFeaturedProductsQueryHandler : IRequestHandler<GetCategoryFeaturedProductsQuery, CommandResult<List<Product>>>
{
    private readonly IProductRepository _context;

    public GetCategoryFeaturedProductsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<Product>>> Handle(GetCategoryFeaturedProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
