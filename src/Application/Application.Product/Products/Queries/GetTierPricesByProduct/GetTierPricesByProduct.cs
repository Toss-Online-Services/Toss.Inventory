namespace Application.Product.Products.Queries.GetTierPricesByProduct;

public record GetTierPricesByProductQuery : IRequest<CommandResult<List<TierPrice>>>
{
}

public class GetTierPricesByProductQueryValidator : AbstractValidator<GetTierPricesByProductQuery>
{
    public GetTierPricesByProductQueryValidator()
    {
    }
}

public class GetTierPricesByProductQueryHandler : IRequestHandler<GetTierPricesByProductQuery, CommandResult<List<TierPrice>>>
{
    private readonly IProductRepository _context;

    public GetTierPricesByProductQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<TierPrice>>> Handle(GetTierPricesByProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
