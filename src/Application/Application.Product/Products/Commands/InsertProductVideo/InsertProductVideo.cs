namespace Application.Product.Products.Commands.InsertProductVideo;

public record InsertProductVideoCommand : IRequest<CommandResult<int>>
{
}

public class InsertProductVideoCommandValidator : AbstractValidator<InsertProductVideoCommand>
{
    public InsertProductVideoCommandValidator()
    {
    }
}

public class InsertProductVideoCommandHandler : IRequestHandler<InsertProductVideoCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public InsertProductVideoCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(InsertProductVideoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
