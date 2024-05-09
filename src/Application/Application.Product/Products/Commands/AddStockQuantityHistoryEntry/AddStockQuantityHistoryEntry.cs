namespace Application.Product.Products.Commands.AddStockQuantityHistoryEntry;

public record AddStockQuantityHistoryEntryCommand : IRequest<CommandResult<bool>>
{
}

public class AddStockQuantityHistoryEntryCommandValidator : AbstractValidator<AddStockQuantityHistoryEntryCommand>
{
    public AddStockQuantityHistoryEntryCommandValidator()
    {
    }
}

public class AddStockQuantityHistoryEntryCommandHandler : IRequestHandler<AddStockQuantityHistoryEntryCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public AddStockQuantityHistoryEntryCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(AddStockQuantityHistoryEntryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
