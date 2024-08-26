namespace Application.Product.Products.Queries.GetPreferredTierPrice;

public record GetPreferredTierPriceQuery : IRequest<CommandResult<TierPrice>>
{
}

public class GetPreferredTierPriceQueryValidator : AbstractValidator<GetPreferredTierPriceQuery>
{
    public GetPreferredTierPriceQueryValidator()
    {
    }
}

public class GetPreferredTierPriceQueryHandler : IRequestHandler<GetPreferredTierPriceQuery, CommandResult<TierPrice>>
{
    private readonly IProductRepository _context;

    public GetPreferredTierPriceQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<TierPrice>> Handle(GetPreferredTierPriceQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
