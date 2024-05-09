namespace Application.Product.Products.Queries.GetManufacturerFeaturedProducts;

public record GetManufacturerFeaturedProductsQuery : IRequest<CommandResult<List<Product>>>
{
}

public class GetManufacturerFeaturedProductsQueryValidator : AbstractValidator<GetManufacturerFeaturedProductsQuery>
{
    public GetManufacturerFeaturedProductsQueryValidator()
    {
    }
}

public class GetManufacturerFeaturedProductsQueryHandler : IRequestHandler<GetManufacturerFeaturedProductsQuery, CommandResult<List<Product>>>
{
    private readonly IProductRepository _context;

    public GetManufacturerFeaturedProductsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<Product>>> Handle(GetManufacturerFeaturedProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
