namespace Application.Product.Products.Queries.GetProductsByIds;

public record GetProductsByIdsQuery : IRequest<CommandResult<List<Product>>>
{
}

public class GetProductsByIdsQueryValidator : AbstractValidator<GetProductsByIdsQuery>
{
    public GetProductsByIdsQueryValidator()
    {
    }
}

public class GetProductsByIdsQueryHandler : IRequestHandler<GetProductsByIdsQuery, CommandResult<List<Product>>>
{
    private readonly IProductRepository _context;

    public GetProductsByIdsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<Product>>> Handle(GetProductsByIdsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
