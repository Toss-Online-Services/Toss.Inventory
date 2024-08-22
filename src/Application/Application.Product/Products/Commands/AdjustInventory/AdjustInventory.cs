
namespace Application.Product.Products.Commands.AdjustInventory;

public record AdjustInventoryCommand : IRequest<CommandResult<bool>>
{
}

public class AdjustInventoryCommandValidator : AbstractValidator<AdjustInventoryCommand>
{
    public AdjustInventoryCommandValidator()
    {
    }
}

public class AdjustInventoryCommandHandler : IRequestHandler<AdjustInventoryCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public AdjustInventoryCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public CommandResult<bool> Handle(AdjustInventoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
