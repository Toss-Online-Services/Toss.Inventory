namespace Application.Product.Products.Commands.InsertRelatedProduct;

public record InsertRelatedProductCommand : IRequest<CommandResult<int>>
{
}

public class InsertRelatedProductCommandValidator : AbstractValidator<InsertRelatedProductCommand>
{
    public InsertRelatedProductCommandValidator()
    {
    }
}

public class InsertRelatedProductCommandHandler : IRequestHandler<InsertRelatedProductCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public InsertRelatedProductCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(InsertRelatedProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
