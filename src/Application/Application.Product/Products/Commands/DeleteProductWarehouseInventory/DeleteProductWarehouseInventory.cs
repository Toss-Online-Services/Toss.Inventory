namespace Application.Product.Products.Commands.DeleteProductWarehouseInventory;

public record DeleteProductWarehouseInventoryCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteProductWarehouseInventoryCommandValidator : AbstractValidator<DeleteProductWarehouseInventoryCommand>
{
    public DeleteProductWarehouseInventoryCommandValidator()
    {
    }
}

public class DeleteProductWarehouseInventoryCommandHandler : IRequestHandler<DeleteProductWarehouseInventoryCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteProductWarehouseInventoryCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteProductWarehouseInventoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
