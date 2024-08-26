namespace Application.Product.Products.Commands.ReverseBookedInventory;

public record ReverseBookedInventoryCommand : IRequest<CommandResult<int>>
{
}

public class ReverseBookedInventoryCommandValidator : AbstractValidator<ReverseBookedInventoryCommand>
{
    public ReverseBookedInventoryCommandValidator()
    {
    }
}

public class ReverseBookedInventoryCommandHandler : IRequestHandler<ReverseBookedInventoryCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public ReverseBookedInventoryCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(ReverseBookedInventoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
