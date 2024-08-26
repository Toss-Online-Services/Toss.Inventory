namespace Application.Product.Products.Commands.BookReservedInventory;

public record BookReservedInventoryCommand : IRequest<CommandResult<bool>>
{
}

public class BookReservedInventoryCommandValidator : AbstractValidator<BookReservedInventoryCommand>
{
    public BookReservedInventoryCommandValidator()
    {
    }
}

public class BookReservedInventoryCommandHandler : IRequestHandler<BookReservedInventoryCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public BookReservedInventoryCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(BookReservedInventoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
