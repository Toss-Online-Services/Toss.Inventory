namespace Application.Product.Products.Commands.DeleteProduct;

public record DeleteProductCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
    }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteProductCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
