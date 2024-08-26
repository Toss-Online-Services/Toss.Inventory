namespace Application.Product.Products.Queries.GetAllProductWarehouseInventoryRecords;

public record GetAllProductWarehouseInventoryRecordsQuery : IRequest<CommandResult<List<ProductWarehouseInventory>>>
{
}

public class GetAllProductWarehouseInventoryRecordsQueryValidator : AbstractValidator<GetAllProductWarehouseInventoryRecordsQuery>
{
    public GetAllProductWarehouseInventoryRecordsQueryValidator()
    {
    }
}

public class GetAllProductWarehouseInventoryRecordsQueryHandler : IRequestHandler<GetAllProductWarehouseInventoryRecordsQuery, CommandResult<List<ProductWarehouseInventory>>>
{
    private readonly IProductRepository _context;

    public GetAllProductWarehouseInventoryRecordsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<ProductWarehouseInventory>>> Handle(GetAllProductWarehouseInventoryRecordsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
