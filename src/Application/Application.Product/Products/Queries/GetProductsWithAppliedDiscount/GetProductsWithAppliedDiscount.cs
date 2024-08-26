namespace Application.Product.Products.Queries.GetProductsWithAppliedDiscount;

public record GetProductsWithAppliedDiscountQuery : IRequest<CommandResult<IPagedList<Product>>>
{
}

public class GetProductsWithAppliedDiscountQueryValidator : AbstractValidator<GetProductsWithAppliedDiscountQuery>
{
    public GetProductsWithAppliedDiscountQueryValidator()
    {
    }
}

public class GetProductsWithAppliedDiscountQueryHandler : IRequestHandler<GetProductsWithAppliedDiscountQuery, CommandResult<IPagedList<Product>>>
{
    private readonly IProductRepository _context;

    public GetProductsWithAppliedDiscountQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<IPagedList<Product>>> Handle(GetProductsWithAppliedDiscountQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
