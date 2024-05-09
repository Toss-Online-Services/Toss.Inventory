namespace Application.Product.Products.Commands.DeleteProducts;

public record DeleteProductsCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteProductsCommandValidator : AbstractValidator<DeleteProductsCommand>
{
    public DeleteProductsCommandValidator()
    {
    }
}

public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteProductsCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
