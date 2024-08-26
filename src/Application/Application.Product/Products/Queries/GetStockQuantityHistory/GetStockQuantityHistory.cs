namespace Application.Product.Products.Queries.GetStockQuantityHistory;

public record GetStockQuantityHistoryQuery : IRequest<CommandResult<IPagedList<StockQuantityHistory>>>
{
}

public class GetStockQuantityHistoryQueryValidator : AbstractValidator<GetStockQuantityHistoryQuery>
{
    public GetStockQuantityHistoryQueryValidator()
    {
    }
}

public class GetStockQuantityHistoryQueryHandler : IRequestHandler<GetStockQuantityHistoryQuery, CommandResult<IPagedList<StockQuantityHistory>>>
{
    private readonly IProductRepository _context;

    public GetStockQuantityHistoryQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<IPagedList<StockQuantityHistory>>> Handle(GetStockQuantityHistoryQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
