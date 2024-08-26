namespace Application.Product.Products.Queries.GetProductBySku;

public record GetProductBySkuQuery : IRequest<CommandResult<Product>>
{
}

public class GetProductBySkuQueryValidator : AbstractValidator<GetProductBySkuQuery>
{
    public GetProductBySkuQueryValidator()
    {
    }
}

public class GetProductBySkuQueryHandler : IRequestHandler<GetProductBySkuQuery, CommandResult<Product>>
{
    private readonly IProductRepository _context;

    public GetProductBySkuQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<Product>> Handle(GetProductBySkuQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
