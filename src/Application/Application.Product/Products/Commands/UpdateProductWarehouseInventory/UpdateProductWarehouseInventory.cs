namespace Application.Product.Products.Commands.UpdateProductWarehouseInventory;

public record UpdateProductWarehouseInventoryCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateProductWarehouseInventoryCommandValidator : AbstractValidator<UpdateProductWarehouseInventoryCommand>
{
    public UpdateProductWarehouseInventoryCommandValidator()
    {
    }
}

public class UpdateProductWarehouseInventoryCommandHandler : IRequestHandler<UpdateProductWarehouseInventoryCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateProductWarehouseInventoryCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateProductWarehouseInventoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
