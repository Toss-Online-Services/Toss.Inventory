namespace Application.Product.Products.Queries.GetTierPrices;

public record GetTierPricesQuery : IRequest<CommandResult<List<TierPrice>>>
{
}

public class GetTierPricesQueryValidator : AbstractValidator<GetTierPricesQuery>
{
    public GetTierPricesQueryValidator()
    {
    }
}

public class GetTierPricesQueryHandler : IRequestHandler<GetTierPricesQuery, CommandResult<List<TierPrice>>>
{
    private readonly IProductRepository _context;

    public GetTierPricesQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<TierPrice>>> Handle(GetTierPricesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
