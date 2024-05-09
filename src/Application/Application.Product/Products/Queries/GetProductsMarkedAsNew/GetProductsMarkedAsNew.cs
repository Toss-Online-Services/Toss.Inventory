namespace Application.Product.Products.Queries.GetProductsMarkedAsNew;

public record GetProductsMarkedAsNewQuery : IRequest<CommandResult<List<Product>>>
{
}

public class GetProductsMarkedAsNewQueryValidator : AbstractValidator<GetProductsMarkedAsNewQuery>
{
    public GetProductsMarkedAsNewQueryValidator()
    {
    }
}

public class GetProductsMarkedAsNewQueryHandler : IRequestHandler<GetProductsMarkedAsNewQuery, CommandResult<List<Product>>>
{
    private readonly IProductRepository _context;

    public GetProductsMarkedAsNewQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<Product>>> Handle(GetProductsMarkedAsNewQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
