namespace Application.Product.Products.Commands.InsertProductWarehouseInventory;

public record InsertProductWarehouseInventoryCommand : IRequest<CommandResult<int>>
{
}

public class InsertProductWarehouseInventoryCommandValidator : AbstractValidator<InsertProductWarehouseInventoryCommand>
{
    public InsertProductWarehouseInventoryCommandValidator()
    {
    }
}

public class InsertProductWarehouseInventoryCommandHandler : IRequestHandler<InsertProductWarehouseInventoryCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public InsertProductWarehouseInventoryCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(InsertProductWarehouseInventoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
